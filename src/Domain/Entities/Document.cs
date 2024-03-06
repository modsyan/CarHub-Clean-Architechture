namespace Mac.CarHub.Domain.Entities;

public class Document: BaseAuditableEntity
{
    public string? Title { get; set; }
    
    public Guid CarId { get; set; }
    public Car Car { get; set; } = null!;
    
    public Guid FileId { get; set; }
    public UploadedFile? File { get; set; }
    
    public Document()
    {
    }
    
    public Document(string title, Guid carId, UploadedFile file)
    {
        Title = title;
        CarId = carId;
        File = file;
    }
}
