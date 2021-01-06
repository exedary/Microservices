using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Api.Domain;

namespace Warehouse.Api.Infrastructure.Database.Mapping
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("items");
            builder.HasKey(e => e.Id).HasName("items_pkey");
            builder.Property(e => e.Model).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Size).IsRequired().HasMaxLength(255);
            builder.Property(e => e.AvailableCount).IsRequired();
            builder.HasData(
                new Item
                {
                    Id = 1,
                    AvailableCount = 10000,
                    Model = "LEGO 8070",
                    Size = "M"
                },
                new Item
                {
                    Id = 2,
                    AvailableCount = 10000,
                    Model = "LEGO 8880",
                    Size = "L"
                },
                new Item
                {
                    Id = 3,
                    AvailableCount = 10000,
                    Model = "LEGO 42070",
                    Size = "L"
                }
                );
        }
    }
}
