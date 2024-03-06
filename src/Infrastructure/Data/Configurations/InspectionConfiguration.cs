using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class InspectionConfiguration: IEntityTypeConfiguration<Inspection>
{
    public void Configure(EntityTypeBuilder<Inspection> builder)
    {
        builder.ToTable("Inspections");
        
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
