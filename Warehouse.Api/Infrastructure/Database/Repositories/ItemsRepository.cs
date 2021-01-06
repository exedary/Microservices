using System;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Api.Domain;
using Warehouse.Api.Domain.Repositories;

namespace Warehouse.Api.Infrastructure.Database.Repositories
{
    internal class ItemsRepository : IItemsRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ItemsRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext ?? throw new ArgumentNullException(nameof(warehouseDbContext));
        }
        public async Task<Item> GetById(int id)
        {
            return await _warehouseDbContext.Items.FindAsync(id);
        }

        public IQueryable<Item> Query()
        {
            return _warehouseDbContext.Items.AsQueryable();
        }
    }
}
