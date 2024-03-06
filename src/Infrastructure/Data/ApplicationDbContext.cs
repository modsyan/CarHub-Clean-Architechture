using System.Reflection;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Color = Mac.CarHub.Domain.Entities.Color;

namespace Mac.CarHub.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    , IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Car> Cars => Set<Car>();
    
    public DbSet<Employee> Employees => Set<Employee>();
    
    public DbSet<Event> Events => Set<Event>();
    
    public DbSet<Make> Makes => Set<Make>();
    
    public DbSet<Model> Models => Set<Model>();
    
    public DbSet<Document> Documents => Set<Document>();
    
    public DbSet<Inspection> Inspections => Set<Inspection>();
    
    public DbSet<Owner> Owners => Set<Owner>();
    
    public DbSet<Broker> Brokers => Set<Broker>();

    public DbSet<ParkingSlot> ParkingSlots => Set<ParkingSlot>();
    
    public DbSet<Release> Releases => Set<Release>();
    
    public DbSet<ReleaseDocument> ReleaseDocuments => Set<ReleaseDocument>();
    
    public DbSet<ReleaseRequest> ReleaseRequests => Set<ReleaseRequest>();
    
    public DbSet<UploadedFile> UploadedFiles => Set<UploadedFile>();
    
    public DbSet<Color> Colors => Set<Color>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
