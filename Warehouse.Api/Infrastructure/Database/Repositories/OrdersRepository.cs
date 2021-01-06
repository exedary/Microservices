using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Api.Domain;
using Warehouse.Api.Domain.Repositories;

namespace Warehouse.Api.Infrastructure.Database.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;
        public OrdersRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext ?? throw new ArgumentNullException(nameof(warehouseDbContext));
        }
        public async Task Add(Order order)
        {
            await _warehouseDbContext.Orders.AddAsync(order);
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _warehouseDbContext.Orders.AsQueryable().Where(o => o.OrderItemUid == id).FirstOrDefaultAsync();
        }
    }
}
