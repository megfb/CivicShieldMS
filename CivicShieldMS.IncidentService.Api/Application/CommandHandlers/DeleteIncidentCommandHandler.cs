using CivicShieldMS.IncidentService.Api.Application.Commands;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.Shared.Common.Domain;
using CivicShieldMS.Shared.Common.Response;
using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.CommandHandlers
{
    public class DeleteIncidentCommandHandler(IIncidentRepository incidentRepository, IUnitOfWork unitOfWork,
        ILogger<DeleteIncidentCommandHandler> logger) : IRequestHandler<DeleteIncidentCommand, Shared.Common.Response.IResult>
    {

        private readonly IIncidentRepository _incidentRepository = incidentRepository ?? throw new ArgumentNullException(nameof(incidentRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ILogger<DeleteIncidentCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        public async Task<Shared.Common.Response.IResult> Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var incident = await _incidentRepository.GetByIdAsync(request.Id);
                _incidentRepository.Delete(incident);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Incident deleted with ID: {IncidentId}", request.Id);
                return new Result(true, "Incident deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting incident with ID: {IncidentId}", request.Id);
                return new ErrorResult(ex.Message);
            }

        }
    }
}
