using System.ComponentModel.DataAnnotations;

namespace ticketSystem.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string Role { get; set; } = string.Empty;
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
