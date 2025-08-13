using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        #region Relacionamento

        public List<AlunoTurmas> AlunoTurmas { get; set; } = new();

        #endregion
    }
}
