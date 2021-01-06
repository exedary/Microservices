using System;
using System.Threading.Tasks;

namespace Warehouse.Api.Domain.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetById(Guid id);
        Task Add(Order order);
    }
}
