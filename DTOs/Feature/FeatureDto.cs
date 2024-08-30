namespace ticketSystem.DTOs.Feature
{
    public class FeatureDto
    {
        public int featureId { get; set; }
        public string featureName { get; set; } = string.Empty;
        public string featureDescription { get; set; } = string.Empty;
        public string featureSummery { get; set; } = string.Empty;
        public string featureStatus { get; set; } = string.Empty;
    }
}
