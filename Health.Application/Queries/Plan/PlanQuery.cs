using AutoMapper;
using Health.Domain.Interfaces.Queries.Plan;
using Health.Domain.Interfaces.Repositories;
using Health.Domain.Models.Response;
using Health.Domain.ViewModel;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Health.Application.Queries.Plan
{
    public class PlanQuery : IPlanQuery
    {
        private readonly IMapper _mapper;
        private readonly IPlanRepository _planRepository;
        private readonly ILogger<PlanQuery> _logger;

        public PlanQuery(IMapper mapper,
            IPlanRepository planRepository,
            ILogger<PlanQuery> logger)
        {
            _mapper = mapper;
            _planRepository = planRepository;
            _logger = logger;
        }
        public async Task<CommonResponse> GetActivePlans()
        {
            try
            {
                _logger.LogInformation("Retrieving all active plans");

                var activePlans = await _planRepository.GetActivePlansAsync();

                if (activePlans == null)
                {
                    _logger.LogWarning("plans not found");
                    return new CommonResponse();
                }
                var mappedResult = _mapper.Map<List<PlanViewModel>>(activePlans);
                return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "Success", mappedResult, nameof(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Process end with ERROR: {nameof(PlanQuery)}");
                return CommonResponse.CreateFailedResponse(HttpStatusCode.InternalServerError, ex.Message, nameof(HttpStatusCode.InternalServerError));
            }
            finally
            {
                _logger.LogInformation("Process end: {Command}", nameof(PlanQuery));
            }
        }

        public async Task<CommonResponse> GetPlan(int Id)
        {
            try
            {
                _logger.LogInformation("Retrieving plan with ID {Id}", Id);

                var merchant = await _planRepository.GetByIdAsync(Id);

                if (merchant == null)
                {
                    _logger.LogWarning("Plan with ID {Id} not found", Id);
                    return new CommonResponse();
                }
                var mappedResult = _mapper.Map<PlanViewModel>(merchant);
                return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "Success", mappedResult, nameof(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Process end with ERROR: {nameof(PlanQuery)}");
                return CommonResponse.CreateFailedResponse(HttpStatusCode.InternalServerError, ex.Message, nameof(HttpStatusCode.InternalServerError));
            }
            finally
            {
                _logger.LogInformation("Process end: {Command}", nameof(PlanQuery));
            }
        }
    }
}
