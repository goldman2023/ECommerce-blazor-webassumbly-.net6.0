using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class ShippingAddressService : IShippingAddress
    {
        private readonly HttpClient _httpClient;

        public ShippingAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ShippingAddress> GetAll(int id)
        {
            var views = await _httpClient.GetFromJsonAsync<ShippingAddress>($"api/ShippingAddress/GetAll/{id}");
            return views;
        }
        public async Task<HttpResponseMessage> Save(ShippingAddress model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/ShippingAddress/Save", model);
            return result;
        }
    }
}
