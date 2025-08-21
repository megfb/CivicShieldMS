using CivicShieldMS.Shared.EventBus.Abstractions;

namespace CivicShieldMS.Shared.EventBus.Events
{
    public class CreateIncidentIntegrationEvent : IntegrationEvent
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReportedBy { get; set; } = default!;
        public DateTime ReportedAt { get; set; }
    }
}
