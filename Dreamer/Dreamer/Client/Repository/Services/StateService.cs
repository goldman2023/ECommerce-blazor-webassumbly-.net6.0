using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class StateService : IState
    {
        private readonly HttpClient _httpClient;

        public StateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(StateView model)
        {
            var result = await _httpClient.PostAsJsonAsync<StateView>("api/State/Delete", model);
            return result;
        }

        public async Task<IList<State>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<State>>("api/State/GetAll");
            return views;
        }

        public async Task<IList<Country>> GetAllCountry()
        {
            var views = await _httpClient.GetFromJsonAsync<List<Country>>("api/State/GetAllCountry");
            return views;
        }

        public async Task<IList<State>> GetAllState(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<State>>($"api/State/GetAllState/{id}");
        }

        public async Task<IList<StateView>> GetAllView()
        {
            var views = await _httpClient.GetFromJsonAsync<List<StateView>>("api/State/GetAllView");
            return views;
        }

        public async Task<State> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<State>($"api/State/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(State model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/State/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(State model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/State/Update", model);
            return result;
        }
    }
}
