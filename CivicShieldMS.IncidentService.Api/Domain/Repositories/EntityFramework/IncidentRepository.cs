using CivicShieldMS.IncidentService.Api.Domain.Entities;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework
{
    public class IncidentRepository(IncidentDbContext context) : IIncidentRepository
    {
        public async Task<Incident> CreateAsync(Incident incident)
        {
            await context.Incidents.AddAsync(incident);
            return incident;
        }

        public void Delete(Incident incident)
        {
            context.Remove(incident);

        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await context.Incidents.ToListAsync();
        }

        public async Task<Incident> GetByIdAsync(string id)
        {
            return await context.Incidents.FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Incident with ID {id} not found.");
        }

        public void Update(Incident incident)
        {
            context.Incidents.Update(incident);
        }
    }
}
