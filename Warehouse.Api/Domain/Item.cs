using System.Collections.Generic;

namespace Warehouse.Api.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public int AvailableCount { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
