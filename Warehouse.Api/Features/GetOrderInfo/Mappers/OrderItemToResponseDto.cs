using Warehouse.Api.Domain;

namespace Warehouse.Api.Features.GetOrderInfo.Mappers
{
    public static class OrderItemToResponseDto
    {
        public static GetOrderInfoResponse ToDto(this Item item)
        {
            return new GetOrderInfoResponse
            {
                Id = item.Id,
                AvailableCount = item.AvailableCount,
                Model = item.Model,
                Size = item.Size
            };
        }
    }
}
