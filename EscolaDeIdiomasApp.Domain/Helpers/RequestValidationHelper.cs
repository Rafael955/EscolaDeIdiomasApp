using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Helpers
{
    public static class RequestValidationHelper
    {
        public static bool IsRequestValidationsOk(dynamic request, out string errors)
        {
            errors = "";

            // Validação dos DataAnnotations
            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                request,
                validationContext,
                validationResults,
                validateAllProperties: true
            );

            if (!isValid)
            {
                errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
                return false;
            }

            return true;
        }
    }
}
