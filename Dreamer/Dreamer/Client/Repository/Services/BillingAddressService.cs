using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class BillingAddressService : IBillingAddress
    {
        private readonly HttpClient _httpClient;

        public BillingAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BillingAddress> GetAll(int id)
        {
            var views = await _httpClient.GetFromJsonAsync<BillingAddress>($"api/BillingAddress/GetAll/{id}");
            return views;
        }
        public async Task<HttpResponseMessage> Save(BillingAddress model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/BillingAddress/Save", model);
            return result;
        }
    }
}
