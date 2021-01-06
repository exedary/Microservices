using MediatR;
using System;
using Warehouse.Api.Infrastructure.ExternalServices.Dto;

namespace Warehouse.Api.Features.WarrantyRequest
{
    public class WarrantyRequest : IRequest<WarrantyDecisionDto>
    {
        public Guid OrderItemUid { get; set; }
        public WarrantyRequest(Guid orderItemUid)
        {
            OrderItemUid = orderItemUid;
        }
    }
}
