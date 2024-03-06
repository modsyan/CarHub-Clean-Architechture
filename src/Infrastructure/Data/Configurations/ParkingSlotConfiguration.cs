using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class ParkingSlotConfiguration: IEntityTypeConfiguration<ParkingSlot>
{
    public void Configure(EntityTypeBuilder<ParkingSlot> builder)
    {
        builder
            .HasMany(ps => ps.Cars)
            .WithOne(c => c.ParkingSlot)
            .HasForeignKey(ps => ps.ParkingSlotId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
