using Dreamer.Shared.DTOs;
using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository.Interface
{
    public interface ICustomerLogin
    {
        Task<UserToken> Login(LoginInfo userInfo);
        Task<UserToken> Register(CustomerMaster userInfo);
    }
}
