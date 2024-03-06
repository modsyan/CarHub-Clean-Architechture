namespace Mac.CarHub.Domain.Entities;

public class Employee: BaseAuditableEntity
{
    public Guid UserId { get; set; }
}
