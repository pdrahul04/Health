using Health.Domain.Entities;

namespace Health.Domain.Interfaces.Repositories
{
    public interface IPlanRepository : IRepository<PlanEntity>
    {
        Task<IEnumerable<PlanEntity>> GetActivePlansAsync();
    }
}
