using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface IOrderBilling
    {
        Task<IList<OrderMaster>> GetAll();
        Task<IList<OrderMaster>> GetAllOrderAdmin();
        Task<IList<OrderMaster>> GetAllpendingOrderAdmin();
        Task<IList<OrderMaster>> GetAllOnGoingOrderAdmin();
        Task<IList<OrderMaster>> GetAlldeliveredOrderAdmin();
        Task<IList<OrderMaster>> GetAllrejectedOrderAdmin();
        Task<IList<OrderMaster>> GetAllOrderAdminDeliver();
        Task<HttpResponseMessage> Save(OrderMaster size);
        Task<HttpResponseMessage> Update(OrderMaster size);
        Task<OrderMaster> GetbyId(long id);
        Task<IList<OrderMaster>> GetOrderDetailsId(string id);
        Task<IList<OrderMaster>> GetOrderCustomer(int id);
        Task<IList<OrderMaster>> GetOrderDeliveryboy(string id);
        Task<IList<OrderMaster>> GetOrderCustomerlatest(int id);
        Task<IList<OrderDetailsView>> GetOrderCustomerDetails(int id);
        Task<HttpResponseMessage> Delete(OrderMaster master);

        //Count
        Task<OrderDetailsView> OrderPending();
        Task<OrderDetailsView> OrderCancel();
        Task<OrderDetailsView> OnGoing();
        Task<OrderDetailsView> TotalIncome();
    }
}
