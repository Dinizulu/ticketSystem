using Microsoft.EntityFrameworkCore;
using ticketSystem.Data;
using ticketSystem.Interfaces;
using ticketSystem.Models;

namespace ticketSystem.Repository
{
    public class BugRepository : IbugRepository
    {
        private readonly AppDbContext _appDbContext;
        public BugRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Bug> CreateBugAsync(Bug bug)
        {
            await _appDbContext.AddAsync(bug);
            await _appDbContext.SaveChangesAsync();
            return new Bug();
        }

        public Task<Bug> DeleteBugAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bug>> GetAllBugAsync()
        {
            return await _appDbContext.bugs.ToListAsync();
        }

        public async Task<Bug> GetBugByIdAsync(int id)
        {
            return await _appDbContext.bugs.FindAsync(id);
        }

        public Task<Bug> UpdateBugAsync(Bug bug)
        {
            throw new NotImplementedException();
        }
    }
}
