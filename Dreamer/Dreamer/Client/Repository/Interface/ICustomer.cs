using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface ICustomer
    {
        Task<IList<CustomerMaster>> GetAll(int id);
        Task<HttpResponseMessage> Save(CustomerMaster model);
        Task<HttpResponseMessage> Update(CustomerMaster model);
        Task<CustomerMaster> GetbyId(int id);
        Task<HttpResponseMessage> Delete(CustomerMaster model);
    }
}
