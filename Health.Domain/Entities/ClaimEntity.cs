namespace Health.Domain.Entities
{
    public class ClaimEntity : BaseEntity
    {
        public int MemberId { get; set; }
        public string ClaimNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ProviderName { get; set; } = string.Empty;
        public ClaimStatus Status { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string? RejectionReason { get; set; }
    }
}
