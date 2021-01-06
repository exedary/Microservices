using MediatR;
using System;
using Warehouse.Api.Features.Dto;

namespace Warehouse.Api.Features.WarrantyRequest
{
    public class WarrantyRequestCommand : IRequest<CommandResult>
    {
        public Guid OrderItemUid { get; set; }
        public WarrantyRequestCommand(Guid orderItemUid)
        {
            OrderItemUid = orderItemUid;
        }
    }
}
