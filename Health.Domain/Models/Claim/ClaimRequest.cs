using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Domain.Models.Claim
{
    public class ClaimRequest
    {
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ProviderName { get; set; } = string.Empty;
    }
}
