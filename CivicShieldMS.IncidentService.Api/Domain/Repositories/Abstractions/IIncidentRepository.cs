using CivicShieldMS.IncidentService.Api.Domain.Entities;

namespace CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions
{
    public interface IIncidentRepository
    {
        Task<Incident> CreateAsync(Incident incident);
        void Update(Incident incident);
        void Delete(Incident incident);
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident> GetByIdAsync(string id);
    }
}
