namespace Warehouse.Api.Features.GetOrderInfo
{
    public class GetOrderInfoResponse
    {
        public int Id { get; set; }
        public int AvailableCount { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
    }
}
