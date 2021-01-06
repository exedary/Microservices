using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Warehouse.Api.Domain;
using Warehouse.Api.Infrastructure.Database.Mapping;

namespace Warehouse.Api.Infrastructure.Database
{
    internal class WarehouseDbContext : DbContext
    {
        public DbSet<Item> Items { get; protected set; }
        public DbSet<Order> Orders { get; protected set; }
        public WarehouseDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected WarehouseDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            builder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        }
    }
}
