using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warranty.Api.Features.GetWarrantyInfo.Dto
{
    public class GetWarrantyInfoResponse
    {
        public string Comment { get; set; }
        public string Status { get; set; }
        public TimeSpan WarrantyDate { get; set; }
    }
}
