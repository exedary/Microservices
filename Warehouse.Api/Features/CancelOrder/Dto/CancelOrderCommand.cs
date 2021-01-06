using MediatR;
using System;
using Warehouse.Api.Features.Dto;

namespace Warehouse.Api.Features.CancelOrder.Dto
{
    public class CancelOrderCommand : IRequest<CommandResult>
    {
        public CancelOrderCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
