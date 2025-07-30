using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Infrastructure.EntityConfig
{
    class PlanEntityConfig : IEntityTypeConfiguration<PlanEntity>
    {
        public void Configure(EntityTypeBuilder<PlanEntity> builder)
        {
            // BaseEntity properties
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.CreatedBy).HasMaxLength(255);
            builder.Property(e => e.UpdatedBy).HasMaxLength(255);
            builder.Property(e => e.IsDeleted).IsRequired();

            // Payment entity properties
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Deductible).HasPrecision(18, 2);
            builder.Property(e => e.MaxCoverage).HasPrecision(18, 2);
            builder.Property(e => e.MonthlyPremium).HasPrecision(18, 2);
            builder.Property(e => e.CoveragePercentage).HasMaxLength(3);
            builder.Property(e => e.Description).HasMaxLength(500);
        }
    }
}
