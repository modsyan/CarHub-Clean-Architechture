using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mac.CarHub.Infrastructure.Data.Configurations;

public class ReleaseDocumentConfiguration: IEntityTypeConfiguration<ReleaseDocument>
{
    public void Configure(EntityTypeBuilder<ReleaseDocument> builder)
    {
        
    }
}
