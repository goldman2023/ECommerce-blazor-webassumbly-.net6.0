using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class CompanyService : ICompany
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Company>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<Company>>("api/Company/GetAll");
            return views;
        }

        public async Task<Company> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Company>($"api/Company/GetbyId/{id}");
        }
        public async Task<HttpResponseMessage> Update(Company model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Company/Update", model);
            return result;
        }
    }
}
