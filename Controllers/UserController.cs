using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using ticketSystem.Data;
using ticketSystem.DTOs.User;
using ticketSystem.Interfaces;
using ticketSystem.Models;
using ticketSystem.Repository;

namespace ticketSystem.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController( IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        //Getting all the users within the system/database

        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GettAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return Enumerable.Empty<UserResponse>();
            }
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }
        //Getting user by their employee ID

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.GetByIdAsync(id);

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToAdd = _mapper.Map<User>(user);
            await _userRepository.InsertUserAsync(userToAdd);
            return Ok("Success");
        }
        //Updating a single user
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UserToUpdateDto updateUser)
        {
            if (!ModelState.IsValid)
                { return BadRequest(ModelState); }
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(updateUser,userToUpdate);
            await _userRepository.UpdateDbAsync();
            return Ok("User has been updated");
        }
        //Deleting a user from the system
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                { return BadRequest(ModelState); }
            var userToDelete = await _userRepository.GetByIdAsync(id);
            if (userToDelete == null)
            { 
                return NotFound();
            }
            await _userRepository.DeleteUserAsync(userToDelete);
            await _userRepository.UpdateDbAsync();
            return Ok("User Deleted");
        }

    }
}
