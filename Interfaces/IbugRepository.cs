using ticketSystem.Models;

namespace ticketSystem.Interfaces
{
    public interface IbugRepository
    {
        Task<List<Bug>> GetAllBugAsync();
        Task<Bug> GetBugByIdAsync(int id);
        Task<Bug> CreateBugAsync(Bug bug);
        Task<Bug> UpdateBugAsync(Bug bug);
        Task<Bug> DeleteBugAsync(int id);
    }
}
