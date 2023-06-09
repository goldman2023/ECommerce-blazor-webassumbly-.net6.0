using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface IState
    {
        Task<IList<State>> GetAll();
        Task<IList<StateView>> GetAllView();
        Task<IList<Country>> GetAllCountry();
        Task<IList<State>> GetAllState(int id);
        Task<HttpResponseMessage> Save(State model);
        Task<HttpResponseMessage> Update(State model);
        Task<State> GetbyId(int id);
        Task<HttpResponseMessage> Delete(StateView model);
    }
}
