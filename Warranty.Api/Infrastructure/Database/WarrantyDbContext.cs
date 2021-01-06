using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Warranty.Api.Infrastructure.Database.Mapping;

namespace Warranty.Api.Infrastructure.Database
{
    internal class WarrantyDbContext : DbContext
    {
        public DbSet<Domain.Warranty> Warranties { get; set; }

        public WarrantyDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected WarrantyDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WarrantyEntityTypeConfiguration());
        }
    }
}
