namespace Health.Domain.Entities
{
    public class PlanEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal MonthlyPremium { get; set; }
        public decimal Deductible { get; set; }
        public int CoveragePercentage { get; set; }
        public decimal MaxCoverage { get; set; }
        public bool IsActive { get; set; }
        public PlanEntity()
        {

        }

        public PlanEntity(string name,
            string description,
            decimal monthlyPremium,
            decimal deductible,
            int coveragePercentage,
            decimal maxCoverage)
        {
            Name = name;
            Description = description;
            MonthlyPremium = monthlyPremium;
            Deductible = deductible;
            CoveragePercentage = coveragePercentage;
            MaxCoverage = maxCoverage;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            CreatedBy = name;
            UpdatedBy = name;
        }
    }
}
