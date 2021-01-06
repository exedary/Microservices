using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Warranty.Api.Domain.Repositories;
using Warranty.Api.Features.WarrantyDecision.Dto;

namespace Warranty.Api.Features.WarrantyDecision
{
    internal class WarrantyDecisionRequestHandler : IRequestHandler<WarrantyDecisionRequest, WarrantyDecisionResponse>
    {
        private readonly IWarrantyRepository _warrantyRepository;
        public WarrantyDecisionRequestHandler(IWarrantyRepository warrantyRepository)
        {
            _warrantyRepository = warrantyRepository;
        }

        public async Task<WarrantyDecisionResponse> Handle(WarrantyDecisionRequest request, CancellationToken cancellationToken)
        {
            var warranty = await _warrantyRepository.GetById(request.Id);
            if (warranty != null)
            {
                var status = warranty.GetStatus(request.IsInStock);
                return new WarrantyDecisionResponse { Decision = status };
            }
            return null;

        }
    }
}
