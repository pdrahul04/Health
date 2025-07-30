namespace Health.Domain.Models.Claim
{
    public class ProcessClaimRequest
    {
        public decimal ApprovedAmount { get; set; }
        public string? RejectionReason { get; set; }
        public bool IsApproved { get; set; }
    }
}
