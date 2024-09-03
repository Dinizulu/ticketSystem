using System.ComponentModel.DataAnnotations;

namespace ticketSystem.DTOs.Bug
{
    public class CreateBugDto
    {
        [Required]
        [MinLength(25, ErrorMessage ="Minimum lengeth is 25 characters")]
        [MaxLength(80, ErrorMessage ="Bug name cannot be longer than 80 characters")]
        public string bugName { get; set; } = string.Empty;
        [Required]
        [MinLength(25, ErrorMessage = "Minimum lengeth is 25 characters")]
        [MaxLength(200, ErrorMessage = "Bug name cannot be longer than 200 characters")]
        public string bugDescription { get; set; } = string.Empty;
        [Required]
        [MinLength(25, ErrorMessage = "Minimum lengeth is 25 characters")]
        [MaxLength(300, ErrorMessage = "Bug name cannot be longer than 300 characters")]
        public string bugSummery { get; set; } = string.Empty;
        [Required]
        public string bugSeverity { get; set; } = string.Empty;
        [Required]
        public string bugStatus { get; set; } = string.Empty;
    }
}
