using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Bug> DeleteBugAsync(Bug bug)
        {
            _appDbContext.bugs.Remove(bug);
            await _appDbContext.SaveChangesAsync();
            return new Bug();
        }

        public async Task<List<Bug>> GetAllBugAsync()
        {
            return await _appDbContext.bugs.ToListAsync();
        }
        //Search for a bug
        public async Task<Bug> GetBugByIdAsync(int id)
        {
            return await _appDbContext.bugs.FindAsync(id);
        }
        //Updating bug table
        public async Task UpdateBugAsync()
        {
             await _appDbContext.SaveChangesAsync();
        }
    }
}
