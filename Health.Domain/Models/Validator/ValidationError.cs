namespace Health.Domain.Models.Validator
{
    public class ValidationError
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public object? AttemptedValue { get; set; }
    }
}
