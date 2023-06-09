using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface ICompany
    {
        Task<IList<Company>> GetAll();
        Task<HttpResponseMessage> Update(Company model);
        Task<Company> GetbyId(int id);
    }
}
