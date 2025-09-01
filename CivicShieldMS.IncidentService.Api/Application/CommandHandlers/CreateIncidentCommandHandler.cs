using CivicShieldMS.IncidentService.Api.Application.Commands;
using CivicShieldMS.IncidentService.Api.Domain.Entities;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.Shared.Common.Domain;
using CivicShieldMS.Shared.Common.Response;
using CivicShieldMS.Shared.EventBus.Abstractions;
using CivicShieldMS.Shared.EventBus.Events;
using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.CommandHandlers
{
    public class CreateIncidentCommandHandler(IIncidentRepository incidentRepository, IUnitOfWork unitOfWork,
        ILogger<CreateIncidentCommandHandler> logger, IEventBus eventBus) : IRequestHandler<CreateIncidentCommand, Shared.Common.Response.IResult>
    {
        private readonly IEventBus _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        private readonly IIncidentRepository _incidentRepository = incidentRepository ?? throw new ArgumentNullException(nameof(incidentRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ILogger<CreateIncidentCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        public async Task<Shared.Common.Response.IResult> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var incident = new Incident()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = request.Title,
                    Description = request.Description,
                    Category = request.Category,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    ReportedBy = request.ReportedBy,
                    ReportedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                };
                await _incidentRepository.CreateAsync(incident);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Incident created with ID: {IncidentId}", incident.Id);

                //await _eventBus.PublishAsync(new CreateIncidentIntegrationEvent
                //{
                //    Id = incident.Id,
                //    Title = incident.Title,
                //    Description = incident.Description,
                //    Category = incident.Category,
                //    Latitude = incident.Latitude,
                //    Longitude = incident.Longitude,
                //    ReportedBy = incident.ReportedBy,
                //    ReportedAt = incident.ReportedAt
                //});
                _logger.LogInformation("Incident integration event published for Incident ID: {IncidentId}", incident.Id);
                return new Result(true, "Incident created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating incident");
                return new ErrorResult(ex.Message);
            }


        }
    }
}
