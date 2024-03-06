namespace Mac.CarHub.Domain.Entities;

public class Car : BaseAuditableEntity
{
    public string BusinessId { get; set; } = String.Empty;
    
    public string EngineSerialNumber { get; set; } = String.Empty;

    public int ModelId { get; set; }
    
    public Model Model { get; set; } = null!;

    public int Year { get; set; }

    public int ColorId { get; set; }
    
    public Color Color { get; set; } = null!;
    
    public List<Inspection> Inspections { get; set; } = [];
    
    public List<Document> Documents { get; set; } = [];
    
    public int? ParkingSlotId { get; set; }
    
    public virtual ParkingSlot? ParkingSlot { get; set; }
    
    public Guid? ReleasedCarId { get; set; }
    
    public virtual Release? Release { get; set; }
    
    public CarStatus Status { get; set; }

    // Needed to change => Start
    public Guid UserId { get; set; }
    
    public Guid? OwnerId { get; set; }
    
    public virtual Owner? Owner { get; set; } = null!;
    
    public Guid? BrokerId { get; set; }
    
    public virtual Broker? Broker { get; set; }
    
    // Needed to change => End
}
