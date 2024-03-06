namespace Mac.CarHub.Infrastructure.Configurations;

public class FileOptions
{
    public static string SectionName => "fileOptions";

    public string WwwRootImagePath { get; set; } = string.Empty;
    public string AllowedImageExtensions { get; set; } = string.Empty;
    public string AllowedAudioExtensions { get; set; } = string.Empty;
    public int MaxImageSizeInMb { get; set; }
    public int MaxAudioSizeInMb { get; set; }
}
