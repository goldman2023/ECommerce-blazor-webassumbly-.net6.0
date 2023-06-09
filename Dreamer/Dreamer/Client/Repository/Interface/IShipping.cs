using Dreamer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dreamer.Client.Repository.Interface
{
    public interface IShipping
    {
        Task<IList<Shipping>> GetAll();
        Task<HttpResponseMessage> Save(Shipping model);
        Task<HttpResponseMessage> Update(Shipping model);
        Task<Shipping> GetbyId(int id);
        Task<HttpResponseMessage> Delete(Shipping model);
    }
}
