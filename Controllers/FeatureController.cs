using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ticketSystem.DTOs.Feature;
using ticketSystem.Interfaces;
using ticketSystem.Models;

namespace ticketSystem.Controllers
{
    [Route("api/features")]
    [ApiController]
    public class FeatureController : Controller
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }
        //Getting all features from the database
        [HttpGet]
        public async Task<IEnumerable<Feature>> GetAllFeatures()
        {
            var features = await _featureRepository.GetAllFeaturesAsync();
            return _mapper.Map<IEnumerable<Feature>>(features);
        }
        //Getting a feature by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeatureById(int id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            var singleFeature = _mapper.Map<Feature>(feature);
            return Ok(singleFeature);
        }
        //Inserting a feature into the database
        [HttpPost]
        public async Task<ActionResult> CreateAFeature(CreateFeatureDto feature)
        {
            var featureToAdd = _mapper.Map<Feature>(feature);
            await _featureRepository.CreateFeatureAsync(featureToAdd);
            return Ok("Feature has been added to the database");
        }
        //Updating a feature status
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAFeature(int id,EditFeatureDto editFeature)
        {
            var featureToUpdate = await _featureRepository.GetByIdAsync(id);
            if(featureToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(editFeature, featureToUpdate);
            await _featureRepository.UpdateFeatureAsync();
            return Ok("Feature status has been updated");
        }
        //Deleting a feature
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var bugToDelete = await _featureRepository.GetByIdAsync(id);
            if(bugToDelete == null)
            {
                return NotFound();
            }
            await _featureRepository.DeleteFeatureAsync(bugToDelete);
            return Ok("Feature has been deleted");
        }
    }
}
