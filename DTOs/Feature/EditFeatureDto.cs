using System.ComponentModel.DataAnnotations;

namespace ticketSystem.DTOs.Feature
{
    public class EditFeatureDto
    {
        [Required]
        public string featureStatus { get; set; } = string.Empty;
    }
}
