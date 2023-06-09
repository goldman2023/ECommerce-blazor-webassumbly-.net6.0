using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public StoreController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Store>>> GetAll()
        {
            var view = await _context.Store.ToListAsync();
            return Ok(view);
        }
        [HttpGet]
        [ActionName("GetAllView")]
        public async Task<ActionResult<IEnumerable<StoreView>>> GetAllView()
        {
            var result = await (from a in _context.Store
                                join b in _context.Cities on a.CitiesId equals b.CitiesId
                                join c in _context.Area on a.AreaId equals c.AreaId
                                select new StoreView
                                {
                                    StoreId = a.StoreId,
                                    Name = a.Name,
                                    Mobile = a.Mobile,
                                    Address = a.Address,
                                    Phone = a.Phone,
                                    Cover = a.Cover,
                                    CategoryName = b.CitiyName,
                                    AreaName = c.AreaName
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        [ActionName("GetStoreInfo")]
        public async Task<ActionResult<UserProfile>> GetStoreInfo(string userIds)
        {
            var user = await _userManager.FindByIdAsync(userIds);
            return new UserProfile
            {
               UserName = user.UserName,
               Email = user.Email
            };
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Store model)
        {
            var result = (from progm in _context.Store
                          where progm.Name == model.Name
                          select progm.StoreId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (userId != null)
                {
                    model.UserId = userId;
                    _context.Store.Add(model);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Store model)
        {
            _context.Store.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.Store.FirstOrDefaultAsync(a => a.StoreId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(StoreView master)
        {
                var dev = await _context.Store.FirstOrDefaultAsync(a => a.StoreId == master.StoreId);
                _context.Store.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
        }

    }
}
