namespace Health.Domain.ViewModel
{
    public class PlanViewModel
    {
        public decimal MonthlyPremium { get; set; }
        public int CoveragePercentage { get; set; }
        public decimal MaxCoverage { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Deductible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
