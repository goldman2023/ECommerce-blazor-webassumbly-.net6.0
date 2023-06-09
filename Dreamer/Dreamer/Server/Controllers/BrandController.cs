
using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly ApplicationDbContext _context;
        public BrandController(ApplicationDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            var view = await _context.Brand.ToListAsync();
            return Ok(view);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Brand model)
        {
            var result = (from progm in _context.Brand
                          where progm.BrandName == model.BrandName
                          select progm.BrandId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var path = $"{env.WebRootPath}//{model.Image}";
                await using var fs = new FileStream(path, FileMode.Create);
                //fs.Write(model.FileContent, 0, model.FileContent.Length);
               new CreatedResult(env.WebRootPath, model.Image);
                model.Image = path;
                _context.Brand.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Brand model)
        {
            _context.Brand.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Brand.FirstOrDefaultAsync(a => a.BrandId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Brand master)
        {
            var result = (from progm in _context.Product
                          where progm.BrandId == master.BrandId
                          select progm.BrandId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var dev = await _context.Brand.FirstOrDefaultAsync(a => a.BrandId == master.BrandId);
                _context.Brand.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

    }
}
