using System;
using Warehouse.Api.Domain.Exceptions;

namespace Warehouse.Api.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public bool Canceled { get; set; }
        public Guid OrderItemUid { get; set; }
        public Guid OrderUid { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public static Order Create(Item item)
        {
            if (item != null)
            {
                if (item.AvailableCount >= 1)
                {
                    var order = new Order
                    {
                        ItemId = item.Id,
                        Item = item,
                        Canceled = false,
                        OrderItemUid = Guid.NewGuid(),
                        OrderUid = Guid.NewGuid()
                    };
                    item.AvailableCount -= 1;
                    return order;
                }
                throw new OutOfStockException("Not enough items in warehouse, " +
                                              $"left in stock: { item.AvailableCount }");
            }
            throw new InvalidOperationException("Requested item not found");
        }

        public void Cancel(Item item)
        {
            if (!Canceled)
            {
                Canceled = true;
                item.AvailableCount += 1;
            }
            else throw new InvalidOperationException("Order already canceled");
        }
    }
}
