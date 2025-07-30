using Health.Domain.Entities;
using Health.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Health.Infrastructure.Data
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options) : base(options)
        {
        }

        public DbSet<PlanEntity> Plans { get; set; }
        public DbSet<MemberEntity> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlanEntityConfig());
            builder.ApplyConfiguration(new MemberEntityConfig());
        }
    }
}
