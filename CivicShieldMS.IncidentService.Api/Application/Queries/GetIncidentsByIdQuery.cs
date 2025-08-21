using CivicShieldMS.IncidentService.Api.Application.Dtos;
using CivicShieldMS.Shared.Common.Response;
using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.Queries
{
    public class GetIncidentsByIdQuery : IRequest<IDataResult<IncidentDto>>
    {
        public string Id { get; set; }
    }
}
