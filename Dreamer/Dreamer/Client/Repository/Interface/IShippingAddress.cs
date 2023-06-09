using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface IShippingAddress
    {
        Task<ShippingAddress> GetAll(int id);
        Task<HttpResponseMessage> Save(ShippingAddress model);
    }
}
