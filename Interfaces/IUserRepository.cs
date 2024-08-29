using ticketSystem.Models;

namespace ticketSystem.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> InsertUserAsync(User user);
        Task UpdateDbAsync();
        Task DeleteUserAsync(User user);
    }
}
