namespace ticketSystem.DTOs.User
{
    public class UserToUpdateDto
    {
        public string Role { get; set; } = string.Empty;
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
