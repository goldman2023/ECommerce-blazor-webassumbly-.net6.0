using Dreamer.Server.Data;
using Dreamer.Shared.DTOs;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dreamer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerLoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public CustomerLoginController(UserManager<IdentityUser> userManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<UserToken>> Create([FromBody] CustomerMaster model)
        {
            //var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = (from progm in _context.CustomerMaster
                          where progm.Email == model.Email && progm.Password == model.Password
                          select progm.CustomerId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.CustomerMaster.Add(model);
                await _context.SaveChangesAsync();
                long id = model.CustomerId;
                if (id > 0)
                {

                    //BillingAddress
                    BillingAddress address = new BillingAddress();
                    address.FirstName = model.FirstName;
                    address.LastName = model.LastName;
                    address.CustomerId = Convert.ToInt32(id);
                    address.Email = model.Email;
                    address.MobileNo = string.Empty;
                    address.PhoneNo = string.Empty;
                    address.CountryId = 1;
                    address.StateId = 1;
                    address.CitiesId = 1;
                    address.AddressName = string.Empty;
                    address.AddedDate = DateTime.Now;
                    _context.BillingAddress.Add(address);
                    _context.SaveChanges();
                    //ShippingAddress
                    ShippingAddress shipping = new ShippingAddress();
                    shipping.FirstName = model.FirstName;
                    shipping.LastName = model.LastName;
                    shipping.CustomerId = Convert.ToInt32(id);
                    shipping.Email = model.Email;
                    shipping.MobileNo = string.Empty;
                    shipping.PhoneNo = string.Empty;
                    shipping.CountryId = 1;
                    shipping.StateId = 1;
                    shipping.CitiesId = 1;
                    shipping.AddressName = string.Empty;
                    shipping.AddedDate = DateTime.Now;
                    _context.ShippingAddress.Add(shipping);
                    _context.SaveChanges();
                    //RoleAdmin
                    //await _userManager.AddToRoleAsync(user, "User");
                    var claims = new List<Claim>()
                    {
                      new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                        //new Claim(ClaimTypes.Name, userinfo.Email),
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.Name, id.ToString())
                    };

                    //claims.AddRange(claimsDB);

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var expiration = DateTime.UtcNow.AddYears(1);

                    JwtSecurityToken token = new JwtSecurityToken(
                          issuer: null,
                       audience: null,
                       claims: claims,
                       expires: expiration,
                       signingCredentials: creds);

                    return new UserToken()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = expiration
                    };
                    //return await BuildToken(userInfo);
                    //return await BuildToken(model);
                }
                else
                {
                    return BadRequest("Username or password invalid");
                }
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginInfo login)
        {
            //var user = new IdentityUser { UserName = login.Email, Email = login.Email };
            var result = (from progm in _context.CustomerMaster
                          where progm.Email == login.Email && progm.Password == login.Password
                          select new CustomerMaster
                          {
                              CustomerId = progm.CustomerId,
                              RoleId = progm.RoleId,
                              Email = progm.Email
                          }).FirstOrDefault();
            if (result == null)
            {
                return BadRequest();
}
else
{
                //RoleAdmin
                //await _userManager.AddToRoleAsync(user, "User");
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, result.CustomerId.ToString()),
                new Claim(ClaimTypes.Email, result.Email),
                new Claim(ClaimTypes.Name, result.RoleId.ToString())
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expiration = DateTime.UtcNow.AddYears(1);

                JwtSecurityToken token = new JwtSecurityToken(
                      issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);

                return new UserToken()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration
                };
            }
            }
    }

}