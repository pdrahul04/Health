namespace Health.Domain.ViewModel
{
    public class ClaimViewModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public string ClaimNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProviderName { get; set; } = string.Empty;
        public decimal ApprovedAmount { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
