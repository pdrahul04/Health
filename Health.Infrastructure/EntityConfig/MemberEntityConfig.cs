using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Infrastructure.EntityConfig
{
    class MemberEntityConfig : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            // BaseEntity properties
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.CreatedBy).HasMaxLength(255);
            builder.Property(e => e.UpdatedBy).HasMaxLength(255);
            builder.Property(e => e.IsDeleted).IsRequired();

            // Payment entity properties
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.PhoneNumber).HasMaxLength(20);
            builder.Property(e => e.Address).HasMaxLength(200);
        }
    }
}
