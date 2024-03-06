namespace Mac.CarHub.Domain.Entities;

public class ReleaseDocument : BaseEntity
{
    public string? Text { get; set; }

    public Guid CarId { get; set; }
    public Car Car { get; set; } = null!;
    
    public Guid ImageId { get; set; }
    public UploadedFile? Image{ get; set; }
}
