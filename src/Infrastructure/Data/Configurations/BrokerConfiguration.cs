using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class BrokerConfiguration : IEntityTypeConfiguration<Broker>
{
    public void Configure(EntityTypeBuilder<Broker> builder)
    {
        builder
            .HasMany(b => b.Cars)
            .WithOne(c=> c.Broker)
            .HasForeignKey(b => b.BrokerId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
