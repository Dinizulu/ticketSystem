using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using ticketSystem.Data;
using ticketSystem.DTOs.User;
using ticketSystem.Models;

namespace ticketSystem.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public UserController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        //Getting all the users within the system/database

        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GettAllUsers()
        {
            var users = await _appDbContext.User.ToListAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }
        //Getting user by their employee ID

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await _appDbContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var singleUser = _mapper.Map<UserResponse>(user);
            return Ok(singleUser);
        }
        //Inserting a single user on the system
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDto user)
        {
            var userToAdd = _mapper.Map<User>(user);
            _appDbContext.User.Add(userToAdd);
            await _appDbContext.SaveChangesAsync();
            return Ok("Success");
        }
        //Updating a single user
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserResponse updateUser)
        {
            var userToUpdate = _appDbContext.User.Find(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(updateUser,userToUpdate);
            _appDbContext.SaveChanges();
            return Ok("User has been updated");
        }
        //Deleting a user from the system
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = _appDbContext.User.Find(id);
            if (userToDelete == null)
            { 
                return NotFound();
            }
            _appDbContext.User.Remove(userToDelete);
            _appDbContext.SaveChanges();
            return Ok();
        }

    }
}
