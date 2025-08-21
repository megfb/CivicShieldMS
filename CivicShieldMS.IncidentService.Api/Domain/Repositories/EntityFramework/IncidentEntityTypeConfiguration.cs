using CivicShieldMS.IncidentService.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework
{
    public class IncidentEntityTypeConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Description).IsRequired().HasMaxLength(500);
            builder.Property(i => i.Category).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Latitude).IsRequired();
            builder.Property(i => i.Longitude).IsRequired();
            builder.Property(i => i.ReportedBy).IsRequired().HasMaxLength(100);
        }
    }
}
