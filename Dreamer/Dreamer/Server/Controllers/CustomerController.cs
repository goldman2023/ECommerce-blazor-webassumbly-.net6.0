using Dreamer.Server.Data;
using Dreamer.Shared;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DatabaseConnection _conn;
        public CustomerController(IConfiguration configuration, ApplicationDbContext context , DatabaseConnection conn)
        {
            _configuration = configuration;
            _context = context;
            _conn = conn;
        }
        [HttpGet("{Id}")]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<CustomerMaster>>> GetAll(int id)
        {
            var result = await (from a in _context.CustomerMaster
                                where a.RoleId == id
                                select new
                                {
                                    CustomerId = a.CustomerId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    RoleId = a.RoleId,
                                    Email = a.Email,
                                    Phone = a.Phone,
                                    MobileNo = a.MobileNo,
                                    Password = a.Password,
                                    ConfirmPassword = a.ConfirmPassword,
                                    Gender = a.Gender,
                                    Address = a.Address,
                                    City = a.City,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    CreatedOn = a.CreatedOn,
                                    ModifiedOn = a.ModifiedOn
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] CustomerMaster model)
        {
                _context.CustomerMaster.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] CustomerMaster model)
        {
            _context.CustomerMaster.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.CustomerMaster.FirstOrDefaultAsync(a => a.CustomerId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(CustomerMaster master)
        {
            SqlConnection sqlcon = new SqlConnection(_conn.DbConn);
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT CustomerId from BillingAddress where CustomerId=@CustomerId) IF NOT EXISTS (SELECT CustomerId from ShippingAddress where CustomerId=@CustomerId) IF NOT EXISTS (SELECT CustomerId from OrderMaster where CustomerId=@CustomerId) DELETE FROM CustomerMaster where CustomerId=@CustomerId", sqlcon);
                cmd.CommandType = CommandType.Text;
                SqlParameter para = new SqlParameter();
                para = cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                para.Value = master.CustomerId;
                long rowAffacted = cmd.ExecuteNonQuery();
                if (rowAffacted > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }
            //var result = (from progm in _context.OrderMaster
            //              where progm.CustomerId == master.CustomerId
            //              select progm.CustomerId).Count();
            //if (result > 0)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    var dev = await _context.CustomerMaster.FirstOrDefaultAsync(a => a.CustomerId == master.CustomerId);
            //    _context.CustomerMaster.Remove(dev);
            //    await _context.SaveChangesAsync();
            //    return Ok(new RegisterResult { Successful = true });
            //}
        }

    }
}
