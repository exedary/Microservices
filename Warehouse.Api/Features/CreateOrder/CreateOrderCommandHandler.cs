using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Domain.Specifications;
using Warehouse.Api.Features.CreateOrder.Dto;
using Warehouse.Api.Features.Dto;
using Warehouse.Api.Infrastructure.Database;
using Warehouse.Api.Infrastructure.ExternalServices;

namespace Warehouse.Api.Features.CreateOrder
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult>
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IWarrantyService _warrantyService;
        private readonly WarehouseDbContext _warehouseDbContext;
        public CreateOrderCommandHandler(IItemsRepository itemsRepository, IOrdersRepository ordersRepository,
                                         WarehouseDbContext warehouseDbContext, IWarrantyService warrantyService)
        {
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
            _warehouseDbContext = warehouseDbContext ?? throw new ArgumentNullException(nameof(warehouseDbContext));
            _warrantyService = warrantyService ?? throw new ArgumentNullException(nameof(warrantyService));
        }

        public async Task<CommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _itemsRepository.Query().GetBySizeAndModel(request.Model, request.Size).FirstOrDefault();
                var order = Order.Create(item);
                await _ordersRepository.Add(order);
                await _warehouseDbContext.SaveChangesAsync();
                await _warrantyService.StartWarranty(order.OrderItemUid);
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
