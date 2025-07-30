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
