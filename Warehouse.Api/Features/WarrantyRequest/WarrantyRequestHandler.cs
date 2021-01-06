using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Infrastructure.ExternalServices;
using Warehouse.Api.Infrastructure.ExternalServices.Dto;

namespace Warehouse.Api.Features.WarrantyRequest
{
    internal class WarrantyRequestHandler : IRequestHandler<WarrantyRequest, WarrantyDecisionDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IItemsRepository _itemsRepository;
        private readonly IWarrantyService _warrantyService;
        public WarrantyRequestHandler(IOrdersRepository ordersRepository, IWarrantyService warrantyService,
                                      IItemsRepository itemsRepository)
        {
            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
            _warrantyService = warrantyService ?? throw new ArgumentNullException(nameof(warrantyService));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        }
        public async Task<WarrantyDecisionDto> Handle(WarrantyRequest request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetById(request.OrderItemUid);
            var item = await _itemsRepository.GetById(order.ItemId);
            if (order != null && item != null)
            {
                var isInStock = item.AvailableCount != 0;
                var result = await _warrantyService.GetWarrantyDecision(order.OrderItemUid, isInStock);
                return new WarrantyDecisionDto { Decision = result.Decision };
            }
            return null;
        }
    }
}
