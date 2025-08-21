using CivicShieldMS.CoordinationService.Api.Domain.Entities;
using CivicShieldMS.CoordinationService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.CoordinationService.Api.Domain.Repositories.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CivicShieldMS.CoordinationService.Api.Domain.Repositories.EntityFramework
{
    public class SupporterRepository(CoordinationDbContext context) : ISupporterRepository
    {

        public async Task<Supporter> AddAsync(Supporter supporter)
        {
            await context.Supporter.AddAsync(supporter);
            return supporter;
        }

        public void Delete(Supporter supporter)
        {
            context.Supporter.Remove(supporter);
        }

        public async Task<IEnumerable<Supporter>> GetAllAsync()
        {
            return await context.Supporter.ToListAsync();
        }

        public async Task<IEnumerable<Supporter>> GetAvailableSupportersAsync(string city, string district)
        {
            return await context.Supporter.Where(x => x.City == city && x.District == district && x.Status == SupporterStatus.Available).ToListAsync();
        }

        public async Task<Supporter> GetByIdAsync(string id)
        {
            return await context.Supporter.FindAsync(id);
        }

        public void Update(Supporter supporter)
        {
            context.Supporter.Update(supporter);
        }
    }
}
