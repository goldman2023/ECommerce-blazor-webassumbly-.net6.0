using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        {
            var view = await _context.Company.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Company model)
        {
            _context.Company.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Company.FirstOrDefaultAsync(a => a.CompanyId == id);
            return Ok(dev);
        }
    }
}
