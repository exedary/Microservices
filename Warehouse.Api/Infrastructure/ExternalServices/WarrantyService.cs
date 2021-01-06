using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Warehouse.Api.Infrastructure.ExternalServices.Dto;

namespace Warehouse.Api.Infrastructure.ExternalServices
{
    public class WarrantyService : IWarrantyService
    {
        private readonly HttpClient _httpClient;
        public WarrantyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WarrantyServiceResponse> DeleteWarranty(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/warranty/{id}");
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<WarrantyServiceResponse>(await response.Content.ReadAsStringAsync()); ;
        }

        public async Task<WarrantyDecisionDto> GetWarrantyDecision(Guid id)
        {
            var response = await _httpClient.PostAsync($"api/warranty/{id}/warranty", null);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<WarrantyDecisionDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<WarrantyServiceResponse> StartWarranty(Guid id)
        {
            var response = await _httpClient.PostAsync($"api/warranty/{id}", null);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<WarrantyServiceResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
