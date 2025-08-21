using CivicShieldMS.Shared.Common.Domain;

namespace CivicShieldMS.IncidentService.Api.Domain.Entities
{
    public class Incident : Entity<string>
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReportedBy { get; set; } = default!;
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    }
}
