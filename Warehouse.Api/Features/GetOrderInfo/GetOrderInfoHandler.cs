using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Features.GetOrderInfo.Mappers;

namespace Warehouse.Api.Features.GetOrderInfo
{
    public class GetOrderInfoHandler : IRequestHandler<GetOrderInfoRequest, GetOrderInfoResponse>
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IOrdersRepository _ordersRepository;
        public GetOrderInfoHandler(IItemsRepository itemsRepository, IOrdersRepository ordersRepository)
        {
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        }
        public async Task<GetOrderInfoResponse> Handle(GetOrderInfoRequest request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetById(request.Id);
            if(order != null)
            {
                var item = await _itemsRepository.GetById(order.ItemId);
                return item?.ToDto();
            }
            return null;   
        }
    }
}
