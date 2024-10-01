using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ticketSystem.DTOs.User;
using ticketSystem.Models;

namespace ticketSystem.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto createUser)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appUser = new AppUser
                {
                    UserName = createUser.firstName,
                    Email = createUser.email
                };
                var userToCreate = await _userManager.CreateAsync(appUser,createUser.password);
                if(userToCreate.Succeeded)
                {
                    var results = await _userManager.AddToRoleAsync(appUser, "User");
                    if(results.Succeeded)
                    {
                        return Ok("User has been created");
                    }else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return StatusCode(500, userToCreate.Errors);
                }
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
