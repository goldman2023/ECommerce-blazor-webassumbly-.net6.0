using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class CustomerService : ICustomer
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(CustomerMaster model)
        {
            var result = await _httpClient.PostAsJsonAsync<CustomerMaster>("api/Customer/Delete", model);
            return result;
        }

        public async Task<IList<CustomerMaster>> GetAll(int id)
        {
            var views = await _httpClient.GetFromJsonAsync<List<CustomerMaster>>($"api/Customer/GetAll/{id}");
            return views;
        }

        public async Task<CustomerMaster> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerMaster>($"api/Customer/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(CustomerMaster model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Customer/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(CustomerMaster model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Customer/Update", model);
            return result;
        }
    }
}
