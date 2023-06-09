using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShippingAddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DatabaseConnection _conn;
        public ShippingAddressController(ApplicationDbContext context, DatabaseConnection conn)
        {
            _context = context;
            _conn = conn;
        }
        [HttpGet("{Id}")]
        [ActionName("GetAll")]
        public async Task<ActionResult> GetAll(int id)
        {
           //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string email = User.FindFirst(ClaimTypes.Email).Value;



            //using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            //{
            //    var para = new DynamicParameters();
            //    para.Add("@CustomerId", userId);
            //    var ListofPlan = sqlcon.Query<Product>("SELECT *FROM ShippingAddress where CustomerId=@CustomerId", para, null, true, 0, commandType: CommandType.Text).FirstOrDefault();
            //    return ListofPlan;
            //}
            var result = await (from a in _context.ShippingAddress
                                where a.CustomerId == id
                                select new
                                {
                                    AddressId = a.AddressId,
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
        public async Task<IActionResult> Save([FromBody] ShippingAddress model)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = (from progm in _context.ShippingAddress
                          where progm.CustomerId == model.CustomerId
                          select progm.AddressId).Count();
            if (result > 0)
            {
                _context.ShippingAddress.Update(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                _context.ShippingAddress.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
