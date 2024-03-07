using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Microsoft.Extensions.DependencyInjection.AvatarGenerator;

public class AvatarGeneratorService : IAvatarGeneratorService
{
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ILogger<AvatarGeneratorService> _logger;

    public AvatarGeneratorService(HttpClient client, ILogger<AvatarGeneratorService> logger,
        IWebHostEnvironment hostingEnvironment)
    {
        _client = client;
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;

        if (!Directory.Exists(ProfilePicturesFolderPath))
        {
            Directory.CreateDirectory(ProfilePicturesFolderPath);
        }
    }

    // folders
    private const string ProfilePicturesFolderPath = "wwwroot/assets/profile-pictures/";

    // files
    private const string DefaultAvatarFilePath = "/assets/templates/default-avatar.png";
    private const string BrokerAvatarFilePath = "/assets/templates/broker-avatar.png";
    private const string AdminAvatarFilePath = "/assets/templates/admin-avatar.png";

    // remote
    private const string BasicRandomAvatarUrl = "https://avatar.iran.liara.run/public";


    public async Task<UploadedFile> GetBrokerAvatar() =>
        await GetLocalAvatar(
            Path.Combine(BrokerAvatarFilePath));

    public async Task<UploadedFile> GetAdminAvatar() =>
        await GetLocalAvatar(AdminAvatarFilePath);

    public async Task<UploadedFile> GetUserAvatar() =>
        await GetLocalAvatar(DefaultAvatarFilePath);

    public async Task<UploadedFile?> AvatarsWithInitialsFromNames(string firstName, string lastName) =>
        await GetRemoteAvatar($"https://avatar.iran.liara.run/username?username={firstName} {lastName}");

    public async Task<UploadedFile?> GetRandomAvatar() =>
        await GetRemoteAvatar(BasicRandomAvatarUrl);

    private async Task<UploadedFile> GetLocalAvatar(string filePath)
    {
        var file = new FileInfo(GetRootPath(filePath));

        return new UploadedFile
        {
            Id = Guid.NewGuid(),
            ContentType = "image/png",
            FileName = file.Name,
            OriginalFileName = file.Name,
            FilePath = filePath,
        };
    }


    private async Task<UploadedFile?> GetRemoteAvatar(string url)
    {
        var response = await _client.GetAsync(url);


        if (!response.IsSuccessStatusCode) return null;

        var contentType = response.Content.Headers.ContentType?.MediaType;
        var originalFileName = response.Content.Headers.ContentDisposition?.FileName;

        var fileExtenstion = !string.IsNullOrWhiteSpace(originalFileName)
            ? Path.GetExtension(originalFileName)
            : ".png";

        var filename = $"avatar_{Guid.NewGuid()}{fileExtenstion}";

        var actualFilePath = $"{ProfilePicturesFolderPath}{filename}";

        var imageStream = await response.Content.ReadAsStreamAsync();
        await using var fileStream = new FileStream(actualFilePath, FileMode.Create);
        await imageStream.CopyToAsync(fileStream);

        return new UploadedFile
        {
            Id = Guid.NewGuid(),
            ContentType = contentType ?? "image/png",
            FileName = filename,
            OriginalFileName = originalFileName ?? filename,
            FilePath = $"/assets/profile-pictures/{filename}",
            FileSize = fileStream.Length
        };
    }

    private string GetRootPath(string filePath) => Path.Combine(_hostingEnvironment.WebRootPath, filePath[1..]);
}
