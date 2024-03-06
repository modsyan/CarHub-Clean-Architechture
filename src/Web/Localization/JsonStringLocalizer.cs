using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Mac.CarHub.Web.Localization;

public class JsonStringLocalizer : IStringLocalizer
{
    private readonly IDistributedCache _cache;
    private readonly JsonSerializer _jsonSerializer = new();

    public JsonStringLocalizer(IDistributedCache cache)
    {
        _cache = cache;
    }

    public IStringLocalizer WithCulture(CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        var cultureName = Thread.CurrentThread.CurrentCulture.Name;
        var filePath = $"Resources/{cultureName}.json";

        using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using StreamReader streamReader = new(stream);
        using JsonTextReader reader = new(streamReader);

        while (reader.Read())
        {
            if (reader.TokenType != JsonToken.PropertyName) continue;

            var key = reader.Value as string;
            reader.Read();

            var value = _jsonSerializer.Deserialize<string>(reader);

            yield return new LocalizedString(key!, value!);
        }
    }

    public LocalizedString this[string name] => GetString(name);

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var format = GetString(name);

            return !format.ResourceNotFound
                ? new LocalizedString(name, string.Format(format.Value, arguments))
                : format;
        }
    }

    private LocalizedString GetString(string key)
    {
        var cultureName = Thread.CurrentThread.CurrentCulture.Name;
        var filePath = $"Resources/{cultureName}.json";

        if (!File.Exists(filePath)) return new LocalizedString(key, string.Empty);

        var cacheKey = $"locale_{cultureName}_{key}";
        var cachedValue = _cache.GetString(cacheKey);

        if (!string.IsNullOrEmpty(cachedValue))
            return new LocalizedString(key, cachedValue);

        var value = GetValueFromJson(key, filePath);
        
        if (!string.IsNullOrEmpty(value))
            _cache.SetString(cacheKey, value,
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });

        return new LocalizedString(key, value);
    }

    private string GetValueFromJson(string propertyName, string filePath)
    {
        if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(filePath))
        {
            return string.Empty;
        }

        using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using StreamReader streamReader = new(stream);
        using JsonTextReader reader = new(streamReader);

        while (reader.Read())
        {
            if (reader.TokenType != JsonToken.PropertyName || reader.Value as string != propertyName) continue;

            reader.Read();
            return _jsonSerializer.Deserialize<string>(reader)!;
        }

        return String.Empty;
    }
}
