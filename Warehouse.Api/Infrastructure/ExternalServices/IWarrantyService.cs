using System;
using System.Threading.Tasks;
using Warehouse.Api.Infrastructure.ExternalServices.Dto;

namespace Warehouse.Api.Infrastructure.ExternalServices
{
    interface IWarrantyService
    {
        public Task<WarrantyServiceResponse> StartWarranty(Guid id);

        public Task<WarrantyServiceResponse> DeleteWarranty(Guid id);

        public Task<WarrantyDecisionDto> GetWarrantyDecision(Guid id);
    }
}
