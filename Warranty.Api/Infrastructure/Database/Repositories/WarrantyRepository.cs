using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Warranty.Api.Domain.Repositories;

namespace Warranty.Api.Infrastructure.Database.Repositories
{
    internal class WarrantyRepository : IWarrantyRepository
    {
        private readonly WarrantyDbContext _warrantyDbContext;
        public WarrantyRepository(WarrantyDbContext warrantyDbContext)
        {
            _warrantyDbContext = warrantyDbContext ?? throw new ArgumentNullException(nameof(warrantyDbContext));
        }

        public async Task Add(Domain.Warranty warranty)
        {
            await _warrantyDbContext.Warranties.AddAsync(warranty);
            await _warrantyDbContext.SaveChangesAsync();
        }

        public async Task<Domain.Warranty> GetById(Guid id)
        {
            return await _warrantyDbContext.Warranties.AsQueryable().Where(w => w.ItemUid == id).FirstOrDefaultAsync();
        }
    }
}
