namespace Mac.CarHub.Domain.Entities;

public class Release : BaseAuditableEntity
{
    public ICollection<ReleaseDocument> Documents { get; set; } = new List<ReleaseDocument>();
    
    public ICollection<ReleaseRequest> ReleaseRequests { get; set; } = new List<ReleaseRequest>();
    
    public DateTime ReleaseDate { get; set; }
    
    public Guid CarId { get; set; }
    
    public Car Car { get; set; } = null!;
}
