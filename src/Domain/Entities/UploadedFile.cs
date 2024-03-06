namespace Mac.CarHub.Domain.Entities;

public class UploadedFile: BaseEntity
{
    public string FilePath { get; set; } = string.Empty;
    
    public string FileName { get; set; } = string.Empty;
    
    public string OriginalFileName { get; set; } = string.Empty;
    
    public string ContentType { get; set; }  = string.Empty;
    
    public long FileSize { get; set; }
}

