namespace Mac.CarHub.Domain.Entities;

public class ReleaseRequest : BaseAuditableEntity
{
    public string? Notes { get; set; }

    public Guid CarId { get; set; }

    public Car Car { get; set; } = null!;

    public RequestStatus Status { get; set; } = RequestStatus.Pending;

    public DateTime? RequestReleaseDate { get; set; } = DateTime.Now;

    public DateTime? AdminReleaseDate { get; set; }

    public ICollection<ReleaseDocument> Documents { get; set; } = new List<ReleaseDocument>();


    public ReleaseRequest(Guid carId, DateTime requestReleaseDate, string notes)
    {
        CarId = carId;
        RequestReleaseDate = requestReleaseDate;
        Notes = notes;
    }

    public ReleaseRequest()
    {
    }
}
