namespace Mac.CarHub.Domain.Entities;

public class Broker: BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
