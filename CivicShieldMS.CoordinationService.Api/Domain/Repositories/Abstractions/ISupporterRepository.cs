using CivicShieldMS.CoordinationService.Api.Domain.Entities;

namespace CivicShieldMS.CoordinationService.Api.Domain.Repositories.Abstractions
{
    public interface ISupporterRepository
    {
        Task<Supporter> GetByIdAsync(string id);
        Task<IEnumerable<Supporter>> GetAllAsync();
        Task<Supporter> AddAsync(Supporter supporter);
        void Update(Supporter supporter);
        void Delete(Supporter supporter);
        Task<IEnumerable<Supporter>> GetAvailableSupportersAsync(string city, string district);
    }
}
