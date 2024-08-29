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
            var bugToAdd = _mapper.Map<Bug>(dto);
            await _ibugRepository.CreateBugAsync(bugToAdd);
            return Ok("Success");
        }

    }
}
