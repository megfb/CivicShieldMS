using CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework.DbContexts;
using CivicShieldMS.Shared.Common.Domain;


namespace CivicShield.IncidentService.Api.Domain.Repositories
{
    public class UnitOfWork(IncidentDbContext context) : IUnitOfWork
    {
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
