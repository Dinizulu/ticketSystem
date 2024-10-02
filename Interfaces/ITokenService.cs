using ticketSystem.Models;

namespace ticketSystem.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
