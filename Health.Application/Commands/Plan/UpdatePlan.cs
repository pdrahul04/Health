using Health.Domain.Interfaces.Repositories;
using Health.Domain.Models.Plan;
using Health.Domain.Models.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Health.Application.Commands.Plan
{
    public class UpdatePlan : PlanRequest, IRequest<CommonResponse>
    {
        public int Id { get; set; }
    }

    public class UpdatePlanHandler : IRequestHandler<UpdatePlan, CommonResponse>
    {
        private readonly IPlanRepository _planRepository;
        private readonly ILogger<UpdatePlanHandler> _logger;

        public UpdatePlanHandler(IPlanRepository planRepository,
            ILogger<UpdatePlanHandler> logger)
        {
            _planRepository = planRepository;
            _logger = logger;
        }

        public async Task<CommonResponse> Handle(UpdatePlan request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Process start: {Command}", nameof(UpdatePlan));
                var plan = await _planRepository.GetByIdAsync(request.Id);
                if (plan == null)
                    throw new ArgumentException("Plan not found");

                if (request.CoveragePercentage < 0 || request.CoveragePercentage > 100)
                    throw new ArgumentException("Coverage percentage must be between 0 and 100");

                if (request.Deductible >= request.MaxCoverage)
                    throw new ArgumentException("Deductible must be less than out-of-pocket maximum");

                plan.Name = request.Name;
                plan.Description = request.Description;
                plan.MonthlyPremium = request.MonthlyPremium;
                plan.Deductible = request.Deductible;
                plan.MaxCoverage = request.MaxCoverage;
                plan.CoveragePercentage = request.CoveragePercentage;
                plan.IsActive = request.IsActive;

                await _planRepository.UpdateAsync(plan);
                var updatedPlan = await _planRepository.GetByIdAsync(plan.Id);
                return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "Success", true, nameof(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Process end with ERROR: {nameof(UpdatePlan)}");
                return CommonResponse.CreateFailedResponse(HttpStatusCode.InternalServerError, ex.Message, nameof(HttpStatusCode.InternalServerError));
            }
            finally
            {
                _logger.LogInformation("Process end: {Command}", nameof(UpdatePlan));
            }
        }
    }
}
