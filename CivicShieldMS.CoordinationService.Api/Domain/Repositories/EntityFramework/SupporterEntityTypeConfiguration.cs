using CivicShieldMS.CoordinationService.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CivicShieldMS.CoordinationService.Api.Domain.Repositories.EntityFramework
{
    public class SupporterEntityTypeConfiguration : IEntityTypeConfiguration<Supporter>
    {
        public void Configure(EntityTypeBuilder<Supporter> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Expertise).IsRequired().HasMaxLength(50);
            builder.Property(e => e.City).IsRequired().HasMaxLength(50);
            builder.Property(e => e.District).IsRequired().HasMaxLength(50);
        }
    }
}
