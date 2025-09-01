using CivicShieldMS.AuthService.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CivicShieldMS.AuthService.Api.Domain.Repositories.Abstractions
{
    public interface IAuthRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> Update(ApplicationUser user);
        Task<IdentityResult> Delete(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);


    }
}
