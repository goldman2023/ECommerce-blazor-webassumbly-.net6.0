using Dapper;
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
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DatabaseConnection _conn;
        public CategoryController(ApplicationDbContext context, DatabaseConnection conn)
        {
            _context = context;
            _conn = conn;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var result = sqlcon.Query<Category>("SELECT *FROM Category", null, null, true, 0, commandType: CommandType.Text).ToList();
                return Ok(result);
            }
        }
        [HttpGet]
        [ActionName("GetAllParent")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllParent()
        {
            var result = await (from a in _context.Category
                                where a.ParentId == 0
                                select new Category
                                {
                                    CategoryId = a.CategoryId,
                                    Name = a.Name,
                                    ParentId = a.ParentId,
                                    Quantity = a.Quantity,
                                    Image = a.Image,
                                    IsActive = a.IsActive
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ActionName("GetAllByCat")]
        public async Task<ActionResult> GetAllByCat(int id)
        {
            var result = await (from a in _context.Category
                                where a.CategoryId == id
                                select new
                                {
                                    CategoryId = a.CategoryId,
                                    Name = a.Name,
                                    ParentId = a.ParentId,
                                    Quantity = a.Quantity,
                                    Image = a.Image,
                                    IsActive = a.IsActive
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Category model)
        {
            //var result = (from progm in _context.Category
            //              where progm.Name == model.Name
            //              select progm.CategoryId).Count();
            //if (result > 0)
            //{
            //    return BadRequest();
            //}
            //else
            //{
                _context.Category.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            //}
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Category model)
        {
            _context.Category.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Category.FirstOrDefaultAsync(a => a.CategoryId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Category master)
        {
            var result = (from progm in _context.Product
                          where progm.CategoryId == master.CategoryId
                          select progm.CategoryId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var dev = await _context.Category.FirstOrDefaultAsync(a => a.CategoryId == master.CategoryId);
                _context.Category.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

    }
}
