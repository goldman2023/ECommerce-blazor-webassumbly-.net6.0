using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class SliderService : ISlider
    {
        private readonly HttpClient _httpClient;

        public SliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(Slider model)
        {
            var result = await _httpClient.PostAsJsonAsync<Slider>("api/Slider/Delete", model);
            return result;
        }

        public async Task<IList<Slider>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<Slider>>("api/Slider/GetAll");
            return views;
        }

        public async Task<Slider> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Slider>($"api/Slider/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(Slider model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Slider/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(Slider model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Slider/Update", model);
            return result;
        }
    }
}
