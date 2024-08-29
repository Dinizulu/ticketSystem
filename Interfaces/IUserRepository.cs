using ticketSystem.Models;

namespace ticketSystem.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task InsertUserAsync(User user);
        Task UpdateDbAsync();
        Task DeleteUserAsync(User user);
    }
}
