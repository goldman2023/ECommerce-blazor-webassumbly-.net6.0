using Dreamer.Server.Data;
using Dreamer.Server.Helpers;
using Dreamer.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class UsersController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var queryable = await context.Users.ToListAsync();
            return Ok(queryable);
        }
        [HttpGet]
        [ActionName("GetRoles")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            var queryable = await context.Roles.ToListAsync();
            return Ok(queryable);
        }
        [HttpPost]
        [ActionName("AssignRole")]
        public async Task<IActionResult> AssignRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.Id);
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.Name));
            return Ok();
        }
        [HttpPost]
        [ActionName("RemoveRole")]
        public async Task<IActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.Id);
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.Name));
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(string id)
        {
            var dev = await context.Users.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }
    }
}
