using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface ICities
    {
        Task<IList<Cities>> GetAll();
        Task<HttpResponseMessage> Save(Cities model);
        Task<HttpResponseMessage> Update(Cities model);
        Task<Cities> GetbyId(int id);
        Task<HttpResponseMessage> Delete(Cities model);
    }
}
