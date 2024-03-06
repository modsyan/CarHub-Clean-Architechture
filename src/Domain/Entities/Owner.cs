namespace Mac.CarHub.Domain.Entities;

public class Owner: BaseEntity
{
    public Guid UserId { get; set; }
    
    public ICollection<Car> Cars { get; set; } = [];
    // public string PhoneNumber { get; set; } = String.Empty;
    // public string NationalityId { get; set; } = String.Empty;
    // public string ResidenceId { get; set; } = String.Empty;
}
