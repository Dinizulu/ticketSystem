using System.ComponentModel.DataAnnotations;

namespace ticketSystem.DTOs.Feature
{
    public class CreateFeatureDto
    {
        [Required]
        [MinLength(25, ErrorMessage = "Minimum feature lengeth is 25 characters")]
        [MaxLength(80, ErrorMessage = "Feature name cannot be longer than 80 characters")]
        public string featureName { get; set; } = string.Empty;
        [Required]
        [MinLength(25, ErrorMessage = "Minimum feature lengeth is 25 characters")]
        [MaxLength(200, ErrorMessage = "Feature name cannot be longer than 200 characters")]
        public string featureDescription { get; set; } = string.Empty;
        [Required]
        [MinLength(25, ErrorMessage = "Minimum feature lengeth is 25 characters")]
        [MaxLength(300, ErrorMessage = "Feature name cannot be longer than 300 characters")]
        public string featureSummery { get; set; } = string.Empty;
        [Required]
        public string featureStatus { get; set; } = string.Empty;
    }
}
