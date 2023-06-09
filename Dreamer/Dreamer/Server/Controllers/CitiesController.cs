using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DatabaseConnection _conn;
        public CitiesController(ApplicationDbContext context , DatabaseConnection conn)
        {
            _context = context;
            _conn = conn;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Cities>>> GetAll()
        {
            var view = await _context.Cities.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Cities model)
        {
            var result = (from progm in _context.Cities
                          where progm.CitiyName == model.CitiyName
                          select progm.CitiesId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.Cities.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Cities model)
        {
            _context.Cities.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Cities.FirstOrDefaultAsync(a => a.CitiesId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Cities master)
        {
            SqlConnection sqlcon = new SqlConnection(_conn.DbConn);
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT CitiesId from BillingAddress where CitiesId=@CitiesId) IF NOT EXISTS (SELECT CitiesId from ShippingAddress where CitiesId=@CitiesId) IF NOT EXISTS (SELECT CitiesId from OrderMaster where CitiesId=@CitiesId) IF NOT EXISTS (SELECT CitiesId from Product where CitiesId=@CitiesId) DELETE FROM Cities where CitiesId=@CitiesId", sqlcon);
                cmd.CommandType = CommandType.Text;
                SqlParameter para = new SqlParameter();
                para = cmd.Parameters.Add("@CitiesId", SqlDbType.Int);
                para.Value = master.CitiesId;
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
            //var result = (from progm in _context.Product
            //              where progm.CitiesId == master.CitiesId
            //              select progm.CitiesId).Count();
            //if (result > 0)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    var dev = await _context.Cities.FirstOrDefaultAsync(a => a.CitiesId == master.CitiesId);
            //    _context.Cities.Remove(dev);
            //    await _context.SaveChangesAsync();
            //    return Ok();
            //}
        }

    }
}
