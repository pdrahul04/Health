using Health.Domain.Interfaces.Repositories;
using Health.Domain.Models.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Health.Application.Commands.Plan
{
    public class DeletePlan : IRequest<CommonResponse>
    {
        public int Id { get; set; }
    }

    public class DeletePlanHandler : IRequestHandler<DeletePlan, CommonResponse>
    {
        private readonly IPlanRepository _planRepository;
        private readonly ILogger<DeletePlanHandler> _logger;

        public DeletePlanHandler(IPlanRepository planRepository,
            ILogger<DeletePlanHandler> logger)
        {
            _planRepository = planRepository;
            _logger = logger;
        }

        public async Task<CommonResponse> Handle(DeletePlan request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Process start: {Command}", nameof(DeletePlan));
                var plan = await _planRepository.GetByIdAsync(request.Id);
                if (plan == null)
                    return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "No Plan", false, nameof(HttpStatusCode.OK));

                await _planRepository.DeleteAsync(request.Id);
                return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "Success", true, nameof(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Process end with ERROR: {nameof(DeletePlan)}");
                return CommonResponse.CreateFailedResponse(HttpStatusCode.InternalServerError, ex.Message, nameof(HttpStatusCode.InternalServerError));
            }
            finally
            {
                _logger.LogInformation("Process end: {Command}", nameof(DeletePlan));
            }
        }
    }
}
