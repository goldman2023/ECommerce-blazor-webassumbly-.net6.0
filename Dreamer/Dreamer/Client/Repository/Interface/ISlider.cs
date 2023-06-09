using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface ISlider
    {
        Task<IList<Slider>> GetAll();
        Task<HttpResponseMessage> Save(Slider model);
        Task<HttpResponseMessage> Update(Slider model);
        Task<Slider> GetbyId(int id);
        Task<HttpResponseMessage> Delete(Slider model);
    }
}
