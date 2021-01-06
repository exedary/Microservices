using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Features.Dto;
using Warehouse.Api.Infrastructure.ExternalServices;
using Warehouse.Api.Infrastructure.ExternalServices.Dto;

namespace Warehouse.Api.Features.WarrantyRequest
{
    public class WarrantyRequestHandler : IRequestHandler<WarrantyRequest, WarrantyDecisionDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IWarrantyService _warrantyService;
        public Task<WarrantyDecisionDto> Handle(WarrantyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
