using Health.Domain.Entities;
using Health.Domain.Enums;

namespace Health.Domain.Interfaces.Repositories
{
    public interface IClaimRepository : IRepository<ClaimEntity>
    {
        Task<IEnumerable<ClaimEntity>> GetClaimsByMemberAsync(int memberId);
        Task<IEnumerable<ClaimEntity>> GetClaimsByStatusAsync(ClaimStatus status);
        Task<ClaimEntity?> GetClaimWithMemberAsync(int id);
        Task<string> GenerateClaimNumberAsync();
    }
}
