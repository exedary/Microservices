using System.Linq;

namespace Warehouse.Api.Domain.Specifications
{
    public static class ItemsSpecifications
    {
        public static IQueryable<Item> GetBySizeAndModel(this IQueryable<Item> items, string model, string size)
        {
            return items.Where(x => x.Model == model && x.Size == size);
        }
    }
}
