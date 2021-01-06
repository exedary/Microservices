using MediatR;
using System;

namespace Warehouse.Api.Features.GetOrderInfo
{
    public class GetOrderInfoRequest : IRequest<GetOrderInfoResponse>
    {
        public Guid Id { get; set; }
    }
}
