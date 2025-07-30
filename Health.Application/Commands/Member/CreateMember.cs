using Health.Domain.Entities;
using Health.Domain.Interfaces.Repositories;
using Health.Domain.Models.Member;
using Health.Domain.Models.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Health.Application.Commands.Member
{
    public class CreateMember : MemberRequest, IRequest<CommonResponse>
    {
    }
    public class CreateMemberHandler : IRequestHandler<CreateMember, CommonResponse>
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly ILogger<CreateMember> _logger;

        public CreateMemberHandler(IPlanRepository planRepository,
            IMemberRepository memberRepository,
            ILogger<CreateMember> logger)
        {
            _planRepository = planRepository;
            _memberRepository = memberRepository;
            _logger = logger;
        }

        public async Task<CommonResponse> Handle(CreateMember request, CancellationToken cancellationToken)
        {
            try
            {
                var plan = await _planRepository.GetByIdAsync(request.PlanId);
                if (plan == null || !plan.IsActive)
                    throw new ArgumentException("Invalid or inactive plan");

                if (await _memberRepository.EmailExistsAsync(request.Email))
                    throw new ArgumentException("Email already exists");

                var member = new MemberEntity
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    PlanId = request.PlanId,
                    CreatedAt = DateTime.Now,
                };

                var createdMember = await _memberRepository.AddAsync(member);
                var memberWithPlan = await _memberRepository.GetMemberWithPlanAsync(createdMember.Id);
                return CommonResponse.CreateSuccessResponse(HttpStatusCode.OK, "Success", plan.Id, nameof(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Process end with ERROR: {nameof(CreateMember)}");
                return CommonResponse.CreateFailedResponse(HttpStatusCode.InternalServerError, ex.Message,
                    nameof(HttpStatusCode.InternalServerError));
            }
            finally
            {
                _logger.LogInformation("Process end: {Command}", nameof(CreateMember));
            }
        }
    }
}
