using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.Models;
using System.Net.Http.Json;

namespace Dreamer.Client.Repository.Services
{
    public class OrderBillingService : IOrderBilling
    {

        private readonly HttpClient _httpClient;

        public OrderBillingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(OrderMaster master)
{
            var result = await _httpClient.PostAsJsonAsync<OrderMaster>("api/OrderBilling/Delete", master);
            return result;
        }

        public async Task<IList<OrderMaster>> GetAll()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAll");
            return views;
        }

        public async Task<IList<OrderMaster>> GetAllOrder()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllOrder");
            return views;
        }
        public async Task<IList<OrderMaster>> GetAllOrderAdmin()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllOrderAdmin");
            return views;
        }

        public async Task<IList<OrderMaster>> GetAllOrderAdminDeliver()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllOrderAdminDeliver");
            return views;
        }

        public async Task<IList<OrderMaster>> GetAllOrderVendor()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllOrderVendor");
            return views;
        }

        public async Task<IList<OrderMaster>> GetAllpendingOrderAdmin()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllpendingOrderAdmin");
            return views;
        }
        public async Task<IList<OrderMaster>> GetAllOnGoingOrderAdmin()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllOnGoingOrderAdmin");
            return views;
        }
        public async Task<IList<OrderMaster>> GetAlldeliveredOrderAdmin()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAlldeliveredOrderAdmin");
            return views;
        }
        public async Task<IList<OrderMaster>> GetAllrejectedOrderAdmin()
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>("api/OrderBilling/GetAllrejectedOrderAdmin");
            return views;
        }


        public async Task<OrderMaster> GetbyId(long id)
        {
            return await _httpClient.GetFromJsonAsync<OrderMaster>($"api/OrderBilling/GetbyId/{id}");
        }

        public async Task<IList<OrderMaster>> GetOrderCustomer(int id)
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>($"api/OrderBilling/GetOrderCustomer/{id}");
            return views;
        }

        public async Task<IList<OrderDetailsView>> GetOrderCustomerDetails(int id)
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderDetailsView>>($"api/OrderBilling/GetOrderCustomerDetails/{id}");
            return views;
        }

        public async Task<IList<OrderMaster>> GetOrderDetailsId(string id)
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>($"api/OrderBilling/GetOrderDetailsId/{id}");
            return views;
        }

        public async Task<OrderDetailsView> OrderPending()
        {
            var views = await _httpClient.GetFromJsonAsync<OrderDetailsView>("api/OrderBilling/OrderPending");
            return views;
        }

        public async Task<OrderDetailsView> OrderCancel()
        {
            var views = await _httpClient.GetFromJsonAsync<OrderDetailsView>("api/OrderBilling/OrderCancel");
            return views;
        }

        public async Task<HttpResponseMessage> Save(OrderMaster model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/OrderBilling/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(OrderMaster model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/OrderBilling/Update", model);
            return result;
        }

        public async Task<OrderDetailsView> OnGoing()
        {
            var views = await _httpClient.GetFromJsonAsync<OrderDetailsView>("api/OrderBilling/OnGoing");
            return views;
        }
        public async Task<OrderDetailsView> TotalIncome()
        {
            var views = await _httpClient.GetFromJsonAsync<OrderDetailsView>("api/OrderBilling/TotalIncome");
            return views;
        }

        public async Task<IList<OrderMaster>> GetOrderCustomerlatest(int id)
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>($"api/OrderBilling/GetOrderCustomerlatest/{id}");
            return views;
        }

        public async Task<IList<OrderMaster>> GetOrderDeliveryboy(string id)
        {
            var views = await _httpClient.GetFromJsonAsync<List<OrderMaster>>($"api/OrderBilling/GetOrderDeliveryboy/{id}");
            return views;
        }
    }
}
