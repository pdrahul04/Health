using Health.Domain.Entities;
using Health.Domain.Interfaces.Repositories;
using Health.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Health.Infrastructure.Repositories
{
    public class PlanRepository : Repository<PlanEntity>, IPlanRepository
    {
        public PlanRepository(HealthDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PlanEntity>> GetActivePlansAsync()
        {
            return await _dbSet
                .Where(p => p.IsActive)
                .ToListAsync();
        }
    }
}
