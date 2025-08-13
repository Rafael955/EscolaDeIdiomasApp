using System.ComponentModel.DataAnnotations;

namespace EscolaDeIdiomasApp.Domain.ValidationAttributes
{
    public class MinCountAttribute : ValidationAttribute
    {
        private readonly int _minCount;

        public MinCountAttribute(int minCount)
        {
            _minCount = minCount;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is ICollection<Guid> list && list.Count >= _minCount)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? $"A lista deve conter pelo menos {_minCount} item(ns).");
        }
    }
}