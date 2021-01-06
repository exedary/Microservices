using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warranty.Api.Features.GetWarrantyInfo.Dto
{
    public class GetWarrantyInfoRequest : IRequest<GetWarrantyInfoResponse>
    {
        public Guid Id { get; set; }
    }
}
