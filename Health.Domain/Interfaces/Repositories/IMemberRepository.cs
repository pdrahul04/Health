using Health.Domain.Entities;

namespace Health.Domain.Interfaces.Repositories
{
    public interface IMemberRepository : IRepository<MemberEntity>
    {
        Task<MemberEntity?> GetMemberWithPlanAsync(int id);
        Task<IEnumerable<MemberEntity>> GetMembersByPlanAsync(int planId);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
    }
}
