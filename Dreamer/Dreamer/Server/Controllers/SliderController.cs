
using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SliderController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Slider>>> GetAll()
        {
            var view = await _context.Slider.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Slider model)
        {
            
                _context.Slider.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Slider model)
        {
            _context.Slider.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Slider.FirstOrDefaultAsync(a => a.SliderId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Slider master)
        {
                var dev = await _context.Slider.FirstOrDefaultAsync(a => a.SliderId == master.SliderId);
                _context.Slider.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
        }

    }
}
