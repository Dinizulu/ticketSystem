using ticketSystem.Models;

namespace ticketSystem.Interfaces
{
    public interface IbugRepository
    {
        Task<List<Bug>> GetAllBugAsync();
        Task<Bug> GetBugByIdAsync(int id);
        Task<Bug> CreateBugAsync(Bug bug);
        Task UpdateBugAsync();
        Task<Bug> DeleteBugAsync(Bug bug);
    }
}
