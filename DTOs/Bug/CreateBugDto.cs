﻿namespace ticketSystem.DTOs.Bug
{
    public class CreateBugDto
    {
        public string bugName { get; set; } = string.Empty;
        public string bugDescription { get; set; } = string.Empty;
        public string bugSummery { get; set; } = string.Empty;
        public string bugSeverity { get; set; } = string.Empty;
        public string bugStatus { get; set; } = string.Empty;
    }
}