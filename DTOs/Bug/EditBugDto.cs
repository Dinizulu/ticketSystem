using System.ComponentModel.DataAnnotations;

namespace ticketSystem.DTOs.Bug
{
    public class EditBugDto
    {
        [Required]
        public string bugSeverity { get; set; } = string.Empty;
        [Required]
        public string bugStatus { get; set; } = string.Empty;
    }
}
