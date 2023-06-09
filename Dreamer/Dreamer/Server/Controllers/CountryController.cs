using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            var view = await _context.Country.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Country model)
        {
            var result = (from progm in _context.Country
                          where progm.Name == model.Name
                          select progm.CountryId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.Country.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Country model)
        {
            _context.Country.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Country.FirstOrDefaultAsync(a => a.CountryId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Country master)
        {
            var result = (from progm in _context.State
                          where progm.CountryId == master.CountryId
                          select progm.CountryId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var dev = await _context.Country.FirstOrDefaultAsync(a => a.CountryId == master.CountryId);
                _context.Country.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

    }
}
