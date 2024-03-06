using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class ReleaseConfiguration : IEntityTypeConfiguration<Release>
{
    public void Configure(EntityTypeBuilder<Release> builder)
    {
        builder.HasOne(e => e.Car)
            .WithOne(c => c.Release)
            .HasForeignKey<Car>(e => e.ReleasedCarId)
            .OnDelete(DeleteBehavior.Restrict)
            ;
    }
}
