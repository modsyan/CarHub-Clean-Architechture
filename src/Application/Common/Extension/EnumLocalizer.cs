using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Mac.CarHub.Application.Common.Interfaces;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Common.Extension;

public class EnumLocalizerService
{
    private readonly IStringLocalizer<EnumLocalizerService> _localizer;

    public EnumLocalizerService(IStringLocalizer<EnumLocalizerService> localizer)
    {
        _localizer = localizer;
    }

    public string GetLocalizedString(string key)
    {
        return _localizer[key];
    }
}

// public class EnumLocalizerRegistry
// {
//     private readonly EnumLocalizerService _localizer;
//
//     public EnumLocalizerRegistry(EnumLocalizerService localizer)
//     {
//         _localizer = localizer;
//     }
//
//     public static EnumLocalizerRegistry Instance { get; private set; } = null!;
//
//     public static void Initialize(EnumLocalizerService localizer)
//     {
//         Instance = new EnumLocalizerRegistry(localizer);
//     }
// }

public static class EnumLocalizerRegistry
{
    private static EnumLocalizerService _localizerService = null!;

    public static void Initialize(EnumLocalizerService localizer)
    {
        _localizerService = localizer;
    }

    public static string GetLocalizedString(string key)
    {
        if (_localizerService == null)
        {
            throw new InvalidOperationException("Localizer is not initialized");
        }

        return _localizerService.GetLocalizedString(key);
    }
}

// public static class EnumLocalizerExtensions
// {
//     private static EnumLocalizerService s_localizer = null!;
//
//     public static void Initialize(EnumLocalizerService localizer)
//     {
//         s_localizer = localizer;
//         // s_localizer = new EnumLocalizerService();
//     }
//
//     public static string GetDisplayName<TEnum>(this TEnum value)
//         where TEnum : Enum
//     {
//         if (s_localizer == null)
//         {
//             throw new InvalidOperationException("Localizer is not initialized");
//         }
//
//         var type = value.GetType();
//         var memberInfo = type.GetMember(value.ToString());
//         var displayAttribute = memberInfo.FirstOrDefault(m => m.GetCustomAttribute<DisplayAttribute>() != null)
//             ?.GetCustomAttribute<DisplayAttribute>();
//
//         return displayAttribute?.Name ?? s_localizer.GetLocalizedString($"Enums_{type.Name}_{value}");
//     }
// }
//

public static class EnumLocalizerExtensions
{
    public static void Initialize(EnumLocalizerService localizer)
    {
        EnumLocalizerRegistry.Initialize(localizer);
    }

    public static string GetDisplayName<TEnum>(this TEnum value)
        where TEnum : Enum
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        
        var displayAttribute = memberInfo.FirstOrDefault(m => m.GetCustomAttribute<DisplayAttribute>() != null)
            ?.GetCustomAttribute<DisplayAttribute>();

        // if (displayAttribute != null)
        // {
        //     return displayAttribute.Name ?? "";
        // }

        return EnumLocalizerRegistry.GetLocalizedString($"Enums_{type.Name}_{value}");
    }
}
