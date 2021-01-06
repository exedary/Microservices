using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Api.Infrastructure.ExternalServices.Dto
{
    public class WarrantyServiceResponse
    {
        public bool IsCompleted { get; set; }
        public string Reason { get; set; }
    }
}
