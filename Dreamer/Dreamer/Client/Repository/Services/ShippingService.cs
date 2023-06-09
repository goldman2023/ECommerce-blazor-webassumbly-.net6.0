using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class ShippingService : IShipping
    {
        private readonly HttpClient _httpClient;

        public ShippingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(Shipping model)
        {
            var result = await _httpClient.PostAsJsonAsync<Shipping>("api/Shipping/Delete", model);
            return result;
        }

        public async Task<IList<Shipping>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<Shipping>>("api/Shipping/GetAll");
            return views;
        }

        public async Task<Shipping> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Shipping>($"api/Shipping/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(Shipping model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Shipping/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(Shipping model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Shipping/Update", model);
            return result;
        }
    }
}
