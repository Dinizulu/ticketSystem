using Microsoft.EntityFrameworkCore;
using ticketSystem.Data;
using ticketSystem.Interfaces;
using ticketSystem.Models;

namespace ticketSystem.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeatureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Feature> CreateFeatureAsync(Feature feature)
        {
            await _appDbContext.features.AddAsync(feature);
            await _appDbContext.SaveChangesAsync();
            return feature;
        }

        public async Task<Feature> DeleteFeatureAsync(Feature feature)
        {
            _appDbContext.features.Remove(feature);
            await _appDbContext.SaveChangesAsync();
            return feature;
        }

        public async Task<List<Feature>> GetAllFeaturesAsync()
        {
            return await _appDbContext.features.ToListAsync();
        }

        public async Task<Feature> GetByIdAsync(int id)
        {
            return await _appDbContext.features.FindAsync(id);
        }

        public async Task UpdateFeatureAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
