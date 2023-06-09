using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface IBrand
    {
        Task<IList<Brand>> GetAll();
        Task<HttpResponseMessage> Save(Brand model);
        Task<HttpResponseMessage> Update(Brand model);
        Task<Brand> GetbyId(int id);
        Task<HttpResponseMessage> Delete(Brand model);
    }
}
