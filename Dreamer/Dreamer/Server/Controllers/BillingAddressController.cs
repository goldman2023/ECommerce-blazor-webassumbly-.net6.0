using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillingAddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BillingAddressController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{Id}")]
        [ActionName("GetAll")]
        public async Task<ActionResult> GetAll(int id)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string email = User.FindFirst(ClaimTypes.Email).Value;
            var result = await (from a in _context.BillingAddress
                                where a.CustomerId == id
                                select new
                                {
                                    DefaultBillingaddressId = a.DefaultBillingaddressId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    Email = a.Email,
                                    PhoneNo = a.PhoneNo,
                                    MobileNo = a.MobileNo,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    CitiesId = a.CitiesId,
                                    AddressName = a.AddressName,
                                    CustomerId = a.CustomerId,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).FirstOrDefaultAsync();
            return Ok(result);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] BillingAddress model)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = (from progm in _context.BillingAddress
                          where progm.CustomerId == model.CustomerId
                          select progm.DefaultBillingaddressId).Count();
            if (result > 0)
            {
                _context.BillingAddress.Update(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                _context.BillingAddress.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
