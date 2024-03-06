using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class FileDto
{
    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    // public long SizeInBytes { get; set; }

    // public byte[]? Data { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UploadedFile, FileDto>();
        }
    }
    
}

//TODO: File Limited to 2MB
//TODO: Accept Extensions: .jpg, .jpeg, .png, .gif, .bmp, .tiff, .svg, webp
//TODO: Accept MIME Types: image/jpeg, image/png, image/gif, image/bmp, image/tiff, image/svg+xml, image/webp
//TODO: File Name: {CarId}-{BrokerId}-{DateTime.Now}
//TODO: File Path: /wwwroot/images/{CarId}/{BrokerId}/{DateTime.Now}
//TODO: File URL: /images/{CarId}/{BrokerId}/{DateTime.Now}
//TODO: File Size: {FileSize} KB
//TODO: File Type: {FileType}
//TODO: File Extension: {FileExtension}
//TODO: File Created: {DateTime.Now}
//TODO: Accept Video Extensions: .mp4, .avi, .mov, .wmv, .flv, .webm, .mkv
//TODO: Accept Video MIME Types: video/mp4, video/x-msvideo, video/quicktime, video/x-ms-wmv, video/x-flv, video/webm, video/x-matroska
