using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Api.Domain;

namespace Warehouse.Api.Infrastructure.Database.Mapping
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order_item");
            builder.HasKey(e => e.Id).HasName("order_item_pkey");
            builder.Property(e => e.OrderUid).IsRequired();
            builder.Property(e => e.OrderItemUid);
            builder.HasIndex(e => e.OrderItemUid).HasDatabaseName("idx_order_item_order_item_uid").IsUnique();
            builder.HasOne(e => e.Item).WithMany(e => e.Orders).HasForeignKey(e => e.ItemId).HasConstraintName("fk_order_item_item_id");
            builder.Property(e => e.Canceled);
        }
    }
}
