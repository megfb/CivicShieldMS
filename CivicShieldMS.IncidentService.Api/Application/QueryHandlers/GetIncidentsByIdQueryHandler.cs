using CivicShieldMS.IncidentService.Api.Application.Dtos;
using CivicShieldMS.IncidentService.Api.Application.Queries;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.Shared.Common.Response;
using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.QueryHandlers
{
    public class GetIncidentsByIdQueryHandler(IIncidentRepository incidentRepository, ILogger<GetAllIncidentQueryHandler> logger) : IRequestHandler<GetIncidentsByIdQuery, IDataResult<IncidentDto>>
    {
        private readonly IIncidentRepository _incidentRepository = incidentRepository ?? throw new ArgumentNullException(nameof(incidentRepository));
        private readonly ILogger<GetAllIncidentQueryHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        public async Task<IDataResult<IncidentDto>> Handle(GetIncidentsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var incident = await _incidentRepository.GetByIdAsync(request.Id);
                _logger.LogInformation("Incident is gotten with id: {Id}", request.Id);
                return new SuccessDataResult<IncidentDto>("Incident is gotten", new IncidentDto
                {
                    Id = incident.Id,
                    Category = incident.Category,
                    Description = incident.Description,
                    Latitude = incident.Latitude,
                    Longitude = incident.Longitude,
                    ReportedBy = incident.ReportedBy,
                    Title = incident.Title,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting incident with id: {Id}", request.Id);
                return new ErrorDataResult<IncidentDto>("An error occurred while getting the incident", null);
            }
        }
    }
}
