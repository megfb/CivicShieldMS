using CivicShieldMS.CoordinationService.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CivicShieldMS.CoordinationService.Api.Domain.Repositories.EntityFramework.DbContexts
{
    public class CoordinationDbContext(DbContextOptions<CoordinationDbContext> options) : DbContext(options)
    {
        public DbSet<Supporter> Supporter { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupporterEntityTypeConfiguration());
        }
    }
}
