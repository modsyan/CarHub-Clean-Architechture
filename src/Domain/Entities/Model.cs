namespace Mac.CarHub.Domain.Entities;

public class Model: BaseEntity
{
    public new int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public int MakeId { get; set; }
    public Make Make { get; set; } = null!;
    
    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
