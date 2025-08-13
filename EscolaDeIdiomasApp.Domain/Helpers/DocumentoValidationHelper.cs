using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Helpers
{
    public static class DocumentoValidationHelper
    {
        public static bool IsCPFValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            static int CalcularDigito(string c, int length)
            {
                var soma = c.Take(length)
                            .Select((d, i) => (d - '0') * (length + 1 - i))
                            .Sum();
                var resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }

            return CalcularDigito(cpf, 9) == (cpf[9] - '0') &&
                   CalcularDigito(cpf, 10) == (cpf[10] - '0');
        }
    }
}
