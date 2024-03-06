using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class DocumentConfiguration: IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents");
        
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
