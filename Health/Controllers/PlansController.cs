using Health.Application.Commands.Plan;
using Health.Domain.Interfaces.Queries.Plan;
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
        private readonly IPlanQuery _planQuery;

        public PlansController(IMediator mediator,
            ILogger<PlansController> logger,
            IPlanQuery planQuery)
        {
            _mediator = mediator;
            _logger = logger;
            _planQuery = planQuery;
        }

        /// <summary>
        /// Get active plans only
        /// </summary>
        [HttpGet("active")]
        public async Task<ActionResult<CommonResponse>> GetActivePlans()
        {
            _logger.LogInformation("Retrieving active plan");

            try
            {
                var response = await _planQuery.GetActivePlans();

                if (response == null)
                {
                    _logger.LogWarning("active plan not found");
                    return NotFound($"active plan not found");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving active plan");
                return StatusCode(500, "An error occurred while retrieving the active plan");
            }
        }

        /// <summary>
        /// Get plan by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse>> GetPlan(int id)
        {
            _logger.LogInformation("Retrieving plan {id}", id);

            try
            {
                var response = await _planQuery.GetPlan(id);

                if (response == null)
                {
                    _logger.LogWarning("plan {id} not found", id);
                    return NotFound($"plan {id} not found");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving plan {id}", id);
                return StatusCode(500, "An error occurred while retrieving the plan");
            }
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

        #region UpdatePlan
        /// <summary>
        /// Update an existing plan
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<CommonResponse>> UpdatePlan(int id, [FromBody] UpdatePlan command)
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
                _logger.LogError(ex, "Error updating plan");
                return StatusCode(500, new CommonResponse
                {
                    Message = "An error occurred while updating the plan"
                });
            }
        }
        #endregion

        #region DeletePlan
        /// <summary>
        /// Delete a plan
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlan(int id)
        {
            try
            {
                if (id > 0)
                {
                    return BadRequest(new CommonResponse
                    {
                        Message = "Command cannot be null"
                    });
                }
                var command = new DeletePlan { Id = id };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating plan");
                return StatusCode(500, new CommonResponse
                {
                    Message = "An error occurred while updating the plan"
                });
            }
        }
        #endregion
    }
}
