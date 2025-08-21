using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.Commands
{
    public class CreateIncidentCommand : IRequest<Shared.Common.Response.IResult>
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReportedBy { get; set; } = default!;
    }
}
