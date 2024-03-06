using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class ReleaseRequestConfiguration: IEntityTypeConfiguration<ReleaseRequest>
{
    public void Configure(EntityTypeBuilder<ReleaseRequest> builder)
    {
        builder.HasKey(rr => rr.Id);
    }
}
