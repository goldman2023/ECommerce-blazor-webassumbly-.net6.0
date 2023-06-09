using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class BrandService : IBrand
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(Brand model)
        {
            var result = await _httpClient.PostAsJsonAsync<Brand>("api/Brand/Delete", model);
            return result;
        }

        public async Task<IList<Brand>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<Brand>>("api/Brand/GetAll");
            return views;
        }

        public async Task<Brand> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Brand>($"api/Brand/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(Brand model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Brand/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(Brand model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Brand/Update", model);
            return result;
        }
    }
}
