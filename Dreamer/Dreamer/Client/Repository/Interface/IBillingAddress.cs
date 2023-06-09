using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface IBillingAddress
    {
        Task<BillingAddress> GetAll(int id);
        Task<HttpResponseMessage> Save(BillingAddress model);
    }
}
