namespace Health.Domain.Models.Plan
{
    public class PlanRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal MonthlyPremium { get; set; }
        public decimal Deductible { get; set; }
        public int CoveragePercentage { get; set; }
        public decimal MaxCoverage { get; set; }
        public bool IsActive { get; set; }
    }
}
