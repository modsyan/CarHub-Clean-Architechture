namespace Mac.CarHub.Domain.Entities;

public class ParkingSlot : BaseEntity
{
    public new int Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;
    
    public int Capacity { get; set; }
    
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
