using System.ComponentModel.DataAnnotations;

namespace ProductManagementDemo.API.Validators
{
    public class CompareWithAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public bool IsLessThan { get; set; }
        public bool IsGreaterThan { get; set; }

        public CompareWithAttribute(string comparisonProperty)
            => _comparisonProperty = comparisonProperty;

        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            var prop = ctx.ObjectType.GetProperty(_comparisonProperty);
            if (prop == null)
                return new ValidationResult($"Unknown property: {_comparisonProperty}");

            var other = prop.GetValue(ctx.ObjectInstance);
            if (value == null || other == null) return ValidationResult.Success;

            if (value is IComparable a && other is IComparable b)
            {
                int cmp = a.CompareTo(b);
                if (IsLessThan && cmp >= 0) return new ValidationResult(ErrorMessage);
                if (IsGreaterThan && cmp <= 0) return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
            => value is not DateTime d || d > DateTime.Now;
        public override string FormatErrorMessage(string name)
            => $"{name} must be a future date";
    }

    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
            => value is not DateTime d || d < DateTime.Now;
        public override string FormatErrorMessage(string name)
            => $"{name} must be a past date";
    }
}
