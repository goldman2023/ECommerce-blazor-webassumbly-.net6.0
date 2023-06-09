using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class ShippingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShippingController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetAll()
        {
            var view = await _context.Shipping.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Shipping model)
        {
            var result = (from progm in _context.Shipping
                          where progm.Title == model.Title
                          select progm.ShippingId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.Shipping.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Shipping model)
        {
            _context.Shipping.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Shipping.FirstOrDefaultAsync(a => a.ShippingId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Shipping master)
        {
            //var result = (from progm in _context.Tax
            //              where progm.TaxId == master.AreaId
            //              select progm.AreaId).Count();
            //if (result > 0)
            //{
            //    return BadRequest();
            //}
            //else
            //{
                var dev = await _context.Shipping.FirstOrDefaultAsync(a => a.ShippingId == master.ShippingId);
                _context.Shipping.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
            //}
        }

    }
}
