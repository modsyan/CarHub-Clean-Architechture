using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);

        // builder.HasOne(c => c.Inspection)
        //     .WithOne(i => i.Car)
        //     .HasForeignKey<Inspection>(i => i.CarId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        // builder.HasOne(c => c.CarDocument)
        //     .WithOne(cd => cd.Car)
        //     .HasForeignKey<CarDocument>(cd => cd.CarId)
        //     .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Release)
            .WithOne(r => r.Car)
            .HasForeignKey<Release>(r => r.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
