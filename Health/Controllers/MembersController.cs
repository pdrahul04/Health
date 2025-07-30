using Health.Domain.Models.Member;
using Health.Domain.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MembersController> _logger;

        public MembersController(IMediator mediator,
            ILogger<MembersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Create a new member
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CommonResponse>> CreateMember([FromBody] MemberRequest command)
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
    }
}
