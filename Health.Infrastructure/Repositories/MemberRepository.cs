using Health.Domain.Entities;
using Health.Domain.Interfaces.Repositories;
using Health.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Health.Infrastructure.Repositories
{
    public class MemberRepository : Repository<MemberEntity>, IMemberRepository
    {
        public MemberRepository(HealthDbContext context) : base(context)
        {
        }

        public async Task<MemberEntity?> GetMemberWithPlanAsync(int id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MemberEntity>> GetMembersByPlanAsync(int planId)
        {
            return await _dbSet
                .Where(m => m.PlanId == planId)
                .ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = _dbSet.Where(m => m.Email == email);
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public override async Task<IEnumerable<MemberEntity>> GetAllAsync()
        {
            return await _dbSet
                .ToListAsync();
        }
    }
}
