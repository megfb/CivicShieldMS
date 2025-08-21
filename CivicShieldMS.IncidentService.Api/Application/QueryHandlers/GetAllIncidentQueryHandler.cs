using CivicShieldMS.IncidentService.Api.Application.Dtos;
using CivicShieldMS.IncidentService.Api.Application.Queries;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.Shared.Common.Response;
using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.QueryHandlers
{
    public class GetAllIncidentQueryHandler(IIncidentRepository incidentRepository,
        ILogger<GetAllIncidentQueryHandler> logger) : IRequestHandler<GetAllIncidentsQuery, IDataResult<IEnumerable<IncidentDto>>>
    {
        private readonly IIncidentRepository _incidentRepository = incidentRepository ?? throw new ArgumentNullException(nameof(incidentRepository));
        private readonly ILogger<GetAllIncidentQueryHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<IDataResult<IEnumerable<IncidentDto>>> Handle(GetAllIncidentsQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var incidents = await _incidentRepository.GetAllAsync();
                _logger.LogInformation("Incidents are gotten");
                return new SuccessDataResult<IEnumerable<IncidentDto>>("All incidents are gotten", incidents.Select(i => new IncidentDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    Category = i.Category,
                    Latitude = i.Latitude,
                    Longitude = i.Longitude,
                    ReportedBy = i.ReportedBy,
                }));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
