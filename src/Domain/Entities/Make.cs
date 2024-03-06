namespace Mac.CarHub.Domain.Entities;

public class Make: BaseEntity
{
    public new int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
