using CivicShieldMS.AuthService.Api.Domain.Entities;
using CivicShieldMS.AuthService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.AuthService.Api.Domain.Repositories.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CivicShieldMS.AuthService.Api.Domain
{
    public class AuthRepository(UserManager<ApplicationUser> context) : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _context = context ?? throw new ArgumentNullException(nameof(context));

        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _context.CreateAsync(user, password);
        }

        public async Task<IdentityResult> Delete(ApplicationUser user)
        {
            return await _context.DeleteAsync(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _context.FindByEmailAsync(email) ?? throw new ArgumentNullException("Tanımlı bir email bulunamadı");
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _context.FindByIdAsync(id) ?? throw new ArgumentNullException("Tanımlı bir kullanıcı bulunamadı");
        }

        public async Task<IdentityResult> Update(ApplicationUser user)
        {
            return await _context.UpdateAsync(user);
        }
    }
}
