using EscolaDeIdiomasApp.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeIdiomasApp.Domain.ValidationAttributes
{
    public class CpfAttribute : ValidationAttribute
    {
        public CpfAttribute()
        {
            ErrorMessage = "O CPF informado é inválido.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string cpf && DocumentoValidationHelper.IsCPFValid(cpf))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}