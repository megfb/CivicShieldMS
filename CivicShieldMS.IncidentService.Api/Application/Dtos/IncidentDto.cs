namespace CivicShieldMS.IncidentService.Api.Application.Dtos
{
    public class IncidentDto
    {
        public string Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReportedBy { get; set; } = default!;
    }
}
