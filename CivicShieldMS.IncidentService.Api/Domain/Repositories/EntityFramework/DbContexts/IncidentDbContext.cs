using CivicShieldMS.IncidentService.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework.DbContexts
{
    public class IncidentDbContext(DbContextOptions<IncidentDbContext> options) : DbContext(options)
    {
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncidentEntityTypeConfiguration());
        }

    }
}
