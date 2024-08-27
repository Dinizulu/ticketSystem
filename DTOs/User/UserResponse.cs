namespace ticketSystem.DTOs.User
{
    public class UserResponse
    {
        public int userId { get; set; }
        public string Role { get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
