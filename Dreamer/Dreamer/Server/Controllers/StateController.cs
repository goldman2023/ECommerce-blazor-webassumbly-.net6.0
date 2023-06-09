using Dreamer.Server.Data;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<State>>> GetAll()
        {
            var view = await _context.State.ToListAsync();
            return Ok(view);
        }
        [HttpGet]
        [ActionName("GetAllView")]
        public async Task<ActionResult<List<StateView>>> GetAllView()
        {
            var result = await (from a in _context.State
                                join b in _context.Country on a.CountryId equals b.CountryId

                                select new StateView
                                {
                                    StateId = a.StateId,
                                    StateName = a.StateName,
                                    Name = b.Name
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllCountry")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountry()
        {
            var view = await _context.Country.ToListAsync();
            return Ok(view);
        }
        [HttpGet("{Id}")]
        [ActionName("GetAllState")]
        public async Task<ActionResult> GetAllState(int id)
        {
            var result = await (from a in _context.State
                                where a.CountryId == id
                                select new
                                {
                                    StateId = a.StateId,
                                    StateName = a.StateName
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] State model)
        {
            var result = (from progm in _context.State
                          where progm.StateName == model.StateName
                          select progm.StateId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.State.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] State model)
        {
            _context.State.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var dev = await _context.State.FirstOrDefaultAsync(a => a.StateId == id);
            return Ok(dev);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(StateView master)
        {
            var result = (from progm in _context.BillingAddress
                          where progm.StateId == master.StateId
                          select progm.StateId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var resultId = (from progm in _context.ShippingAddress
                              where progm.StateId == master.StateId
                              select progm.StateId).Count();
                if (resultId > 0)
                {
                    return BadRequest();
                }
                else
                {
                    var dev = await _context.State.FirstOrDefaultAsync(a => a.StateId == master.StateId);
                    _context.State.Remove(dev);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

    }
}
