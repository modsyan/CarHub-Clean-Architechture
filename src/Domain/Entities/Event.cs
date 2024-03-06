using System.Reflection;

namespace Mac.CarHub.Domain.Entities;

public class Event : BaseAuditableEntity
{
    public EventType EventType { get; set; }
    public string Description { get; set; } = null!;
    public Guid CarId { get; set; }
    public Car Car { get; set; } = null!;
}

