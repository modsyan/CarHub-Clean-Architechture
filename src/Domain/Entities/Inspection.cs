namespace Mac.CarHub.Domain.Entities;

public class Inspection: BaseAuditableEntity
{
    public string Text { get; set; } = String.Empty;
    
    public Guid CarId { get; set; }
    public virtual Car Car { get; set; } = null!;
    
    public Guid FileId { get; set; }
    public UploadedFile File { get; set; } = null!;
}
