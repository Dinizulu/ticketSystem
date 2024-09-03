using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ticketSystem.DTOs.User
{
    public class CreateUserDto
    {
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Minimum first name lengeth is 10 characters")]
        [MaxLength(80, ErrorMessage = "First name cannot be longer than 80 characters")]
        public string firstName { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Minimum first name lengeth is 10 characters")]
        [MaxLength(80, ErrorMessage = "First name cannot be longer than 80 characters")]
        public string lastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText]
        public string password { get; set; } = string.Empty;
    }
}
