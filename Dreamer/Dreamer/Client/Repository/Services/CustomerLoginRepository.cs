using Dreamer.Client.Helpers;
using Dreamer.Client.Repository.Interface;
using Dreamer.Shared.DTOs;
using Dreamer.Shared.Models;

namespace Dreamer.Client.Repository
{
    public class CustomerLoginRepository : ICustomerLogin
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/CustomerLogin";

        public CustomerLoginRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<UserToken> Register(CustomerMaster userInfo)
        {
            var httpResponse = await httpService.Post<CustomerMaster, UserToken>($"{baseURL}/create", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<UserToken> Login(LoginInfo userInfo)
        {
            var httpResponse = await httpService.Post<LoginInfo, UserToken>($"{baseURL}/login", userInfo);

            if (!httpResponse.Success)
            {
                //throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }
    }
}
