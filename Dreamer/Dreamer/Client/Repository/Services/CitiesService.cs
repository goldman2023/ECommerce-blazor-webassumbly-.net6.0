using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class CitiesService : ICities
    {
        private readonly HttpClient _httpClient;

        public CitiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(Cities model)
        {
            var result = await _httpClient.PostAsJsonAsync<Cities>("api/Cities/Delete", model);
            return result;
        }

        public async Task<IList<Cities>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<Cities>>("api/Cities/GetAll");
            return views;
        }

        public async Task<Cities> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Cities>($"api/Cities/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(Cities model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Cities/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(Cities model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Cities/Update", model);
            return result;
        }
    }
}
