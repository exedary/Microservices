using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warranty.Api.Infrastructure.Database.Mapping
{
    public class WarrantyEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Warranty>
    {
        public void Configure(EntityTypeBuilder<Domain.Warranty> builder)
        {
            builder.ToTable("warranty");

            builder.HasKey(e => e.Id).HasName("warranty_pkey");
            builder.Property(e => e.Comment).HasMaxLength(1024);
            builder.Property(e => e.ItemUid).IsRequired();
            builder.HasIndex(e => e.ItemUid).IsUnique().HasDatabaseName("idx_warranty_item_uid");
            builder.Property(e => e.Status).HasMaxLength(255).IsRequired();
            builder.Property(e => e.WarrantyDate).IsRequired();
        }
    }
}
