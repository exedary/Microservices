using Warranty.Api.Features.GetWarrantyInfo.Dto;

namespace Warranty.Api.Features.GetWarrantyInfo.Mappers
{
    public static class WarrantyToResponseDto
    {
        public static GetWarrantyInfoResponse ToResponseDto(this Domain.Warranty warranty)
        {
            return new GetWarrantyInfoResponse
            {
                Comment = warranty.Comment,
                Status = warranty.Status,
                WarrantyDate = warranty.WarrantyDate
            };
        }
    }
}
