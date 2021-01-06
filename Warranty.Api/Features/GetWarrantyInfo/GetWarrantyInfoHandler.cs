using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Warranty.Api.Domain.Repositories;
using Warranty.Api.Features.GetWarrantyInfo.Dto;
using Warranty.Api.Features.GetWarrantyInfo.Mappers;

namespace Warranty.Api.Features.GetWarrantyInfo
{
    internal class GetWarrantyInfoHandler : IRequestHandler<GetWarrantyInfoRequest, GetWarrantyInfoResponse>
    {
        private readonly IWarrantyRepository _warrantyRepository;
        public GetWarrantyInfoHandler(IWarrantyRepository warrantyRepository)
        {
            _warrantyRepository = warrantyRepository;
        }
        public async Task<GetWarrantyInfoResponse> Handle(GetWarrantyInfoRequest request, CancellationToken cancellationToken)
        {
            var warranty = await _warrantyRepository.GetById(request.Id);
            if (warranty != null)
            {
                return warranty.ToResponseDto();
            }
            return null;
        }
    }
}
