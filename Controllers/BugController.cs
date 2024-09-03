using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ticketSystem.DTOs.Bug;
using ticketSystem.Interfaces;
using ticketSystem.Models;
using ticketSystem.Repository;

namespace ticketSystem.Controllers
{
    [Route("api/bugs")]
    [ApiController]
    public class BugController : Controller
    {
        private readonly IbugRepository _ibugRepository;
        private readonly IMapper _mapper;
        public BugController(IbugRepository bugRepository, IMapper mapper)
        {
            _ibugRepository = bugRepository;
            _mapper = mapper;
        }
        //Getting all the bugs
        [HttpGet]
        public async Task<IEnumerable<Bug>> GetAll()
        {
            var bugs = await _ibugRepository.GetAllBugAsync();
            return _mapper.Map<IEnumerable<Bug>>(bugs);
        }
        //Getting an issue by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetBugById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bug = await _ibugRepository.GetBugByIdAsync(id);
            if (bug == null)
            {
                return NotFound();
            }
            var SingleBug = _mapper.Map<Bug>(bug);
            return Ok(SingleBug);
        }
        //Insering/adding a bug to database
        [HttpPost]
        public async Task<ActionResult> CreateBug(CreateBugDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bugToAdd = _mapper.Map<Bug>(dto);
            await _ibugRepository.CreateBugAsync(bugToAdd);
            return Ok("Success");
        }
        //Updating a bug severity and status
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBug(int id, EditBugDto editBugDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bugToUpdate = await  _ibugRepository.GetBugByIdAsync(id);
            if(bugToUpdate == null)
            {
                return  NotFound();
            }
            _mapper.Map(editBugDto, bugToUpdate);
            await _ibugRepository.UpdateBugAsync();
            return Ok("Bug severity and status updated");

        }
        //Deleting a bug by Id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBug(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bugToDelete = await _ibugRepository.GetBugByIdAsync(id);
            if( bugToDelete == null)
            {
                return NotFound();
            }
            await _ibugRepository.DeleteBugAsync(bugToDelete);
            return Ok("Bug deleted");
        }

    }
}
