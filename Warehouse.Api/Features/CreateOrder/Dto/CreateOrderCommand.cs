using MediatR;
using Warehouse.Api.Features.Dto;

namespace Warehouse.Api.Features.CreateOrder.Dto
{
    public class CreateOrderCommand : IRequest<CommandResult>
    {
        public string Size { get; set; }
        public string Model { get; set; }
    }
}
