using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Features.CancelOrder.Dto;
using Warehouse.Api.Features.Dto;
using Warehouse.Api.Infrastructure.Database;
using Warehouse.Api.Infrastructure.ExternalServices;

namespace Warehouse.Api.Features.CancelOrder
{
    internal class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CommandResult>
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IWarrantyService _warrantyService;
        private readonly WarehouseDbContext _warehouseDbContext;

        public CancelOrderCommandHandler(IItemsRepository itemsRepository, IOrdersRepository ordersRepository,
                                         WarehouseDbContext warehouseDbContext, IWarrantyService warrantyService)
        {
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
            _warehouseDbContext = warehouseDbContext ?? throw new ArgumentNullException(nameof(warehouseDbContext));
            _warrantyService = warrantyService ?? throw new ArgumentNullException(nameof(warrantyService));
        }

        public async Task<CommandResult> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var order = await _ordersRepository.GetById(request.Id);
                var item = await _itemsRepository.GetById(order.ItemId);
                order.Cancel(item);
                await _warehouseDbContext.SaveChangesAsync();
                await _warrantyService.DeleteWarranty(order.OrderItemUid);
                return new CommandResult
                {
                    IsCompleted = true
                };
            }
            catch (Exception ex)
            {
                return new CommandResult
                {
                    IsCompleted = false,
                    Reason = ex.Message
                };
            }
        }
    }
}
