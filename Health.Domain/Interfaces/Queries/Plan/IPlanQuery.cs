using Health.Domain.Models.Response;

namespace Health.Domain.Interfaces.Queries.Plan
{
    public interface IPlanQuery
    {
        Task<CommonResponse> GetPlan(int Id);
        Task<CommonResponse> GetActivePlans();
    }
}
