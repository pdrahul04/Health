using Health.Domain.Entities;
using Health.Domain.Interfaces.Repositories;
using Health.Domain.Models.Plan;
using Health.Domain.Models.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Health.Application.Commands.Plan
{
    public class CreatePlan : PlanRequest, IRequest<CommonResponse>
    {
    }
    public class CreatePlanHandler : IRequestHandler<CreatePlan, CommonResponse>
    {
        private readonly IPlanRepository _planRepository;
        private readonly ILogger<CreatePlan> _logger;

        public CreatePlanHandler(IPlanRepository planRepository,
            ILogger<CreatePlan> logger)
        {
            _planRepository = planRepository;
            _logger = logger;
        }

        public async Task<CommonResponse> Handle(CreatePlan request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Process start: {Command}", nameof(CreatePlan));
                var plan = new PlanEntity(request.Name, request.Description,
                    request.MonthlyPremium,
                    request.Deductible,
                    request.CoveragePercentage,
                    request.MaxCoverage);

                var planId = await _planRepository.AddAsync(plan);
                return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "Success", planId, nameof(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Process end with ERROR: {nameof(CreatePlan)}");
                return CommonResponse.CreateFailedResponse(HttpStatusCode.InternalServerError, ex.Message,
                    nameof(HttpStatusCode.InternalServerError));
            }
            finally
            {
                _logger.LogInformation("Process end: {Command}", nameof(CreatePlan));
            }
        }
    }
}
