using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ticketSystem.DTOs.User;
using ticketSystem.Interfaces;
using ticketSystem.Models;

namespace ticketSystem.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
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
                        return Ok(new NewUserDto
                        {
                            UserName = createUser.firstName,
                            Email = createUser.email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return StatusCode(500, userToCreate.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Loggin(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if(user == null)
            {
                return Unauthorized($"Invalid user: {loginDto.Username}");
            }
            var existingUser = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if(!existingUser.Succeeded)
            {
                return Unauthorized("Username or password incorrect");
            }
            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}
