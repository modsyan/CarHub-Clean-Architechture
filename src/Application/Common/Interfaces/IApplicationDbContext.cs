// using Mac.CarHub.Domain.Entities;

using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Car> Cars { get; }
    
    DbSet<Employee> Employees { get; }
    
    DbSet<Event> Events { get; }
    
    DbSet<Make> Makes { get; }
    
    DbSet<Model> Models { get; }
    
    DbSet<Document> Documents { get; }
    
    DbSet<Inspection> Inspections { get; }
    
    DbSet<Owner> Owners { get; }
    
    DbSet<Broker> Brokers { get; }
    
    DbSet<ParkingSlot> ParkingSlots { get; }
    
    DbSet<Release> Releases { get; }
    
    DbSet<ReleaseDocument> ReleaseDocuments { get; }
    
    DbSet<ReleaseRequest> ReleaseRequests { get; }
    
    DbSet<Color> Colors { get; }
    
    DbSet<UploadedFile> UploadedFiles { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    int SaveChanges();
}
