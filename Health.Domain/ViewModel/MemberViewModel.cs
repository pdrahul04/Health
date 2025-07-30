namespace Health.Domain.ViewModel
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
        public int PlanId { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal MonthlyPremium { get; set; }
    }
}
