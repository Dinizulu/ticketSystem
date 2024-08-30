using ticketSystem.Models;

namespace ticketSystem.Interfaces
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetAllFeaturesAsync();
        Task<Feature> GetByIdAsync(int id);
        Task<Feature> CreateFeatureAsync(Feature feature);
        Task UpdateFeatureAsync();
        Task<Feature> DeleteFeatureAsync(Feature feature);
    }
}
