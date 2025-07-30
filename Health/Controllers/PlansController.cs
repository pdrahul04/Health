using Health.Application.Commands.Plan;
using Health.Domain.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PlansController> _logger;

        public PlansController(IMediator mediator,
            ILogger<PlansController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region CreatePlan
        /// <summary>
        /// Creates a new plan
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CommonResponse>> CreatePlan([FromBody] CreatePlan command)
        {
            try
            {
                if (command == null)
                {
                    return BadRequest(new CommonResponse
                    {
                        Message = "Command cannot be null"
                    });
                }
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating plan");
                return StatusCode(500, new CommonResponse
                {
                    Message = "An error occurred while creating the plan"
                });
            }
        }
        #endregion
    }
}
