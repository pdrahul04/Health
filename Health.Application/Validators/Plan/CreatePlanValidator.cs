using FluentValidation;
using Health.Application.Commands.Plan;

namespace Health.Application.Validators.Plan
{
    public class CreatePlanValidator : AbstractValidator<CreatePlan>
    {
        public CreatePlanValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.MonthlyPremium)
                .GreaterThan(0).WithMessage("Monthly Premium must be greater than zero.");
            RuleFor(x => x.CoveragePercentage)
                .InclusiveBetween(0, 100).WithMessage("Coverage Percentage must be between 0 and 100.");
            RuleFor(x => x.MaxCoverage)
                .GreaterThan(0).WithMessage("Max Coverage must be greater than zero.");
            RuleFor(x => x.Deductible)
                .GreaterThanOrEqualTo(0).WithMessage("Deductible must be zero or greater.");
        }
    }
}
