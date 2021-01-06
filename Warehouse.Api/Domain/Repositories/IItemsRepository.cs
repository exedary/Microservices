using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Api.Domain.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetById(int id);
        IQueryable<Item> Query();
    }
}
