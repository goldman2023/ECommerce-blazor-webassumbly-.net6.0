using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AreaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AreaController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Area>>> GetAll()
        {
            var view = await _context.Area.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Area model)
        {
            var result = (from progm in _context.Area
                          where progm.AreaName == model.AreaName
                          select progm.AreaId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.Area.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Area model)
        {
            _context.Area.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Area.FirstOrDefaultAsync(a => a.AreaId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Area master)
        {
            var result = (from progm in _context.Product
                          where progm.AreaId == master.AreaId
                          select progm.AreaId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var dev = await _context.Area.FirstOrDefaultAsync(a => a.AreaId == master.AreaId);
                _context.Area.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

    }
}
