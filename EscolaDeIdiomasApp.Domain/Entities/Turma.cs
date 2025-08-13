using EscolaDeIdiomasApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Entities
{
    public class Turma
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Numero { get; set; }

        public int Ano { get; set; }

        public NivelTurma NivelTurma { get; set; }

        #region Relacionamentos

        public List<AlunoTurmas>? AlunoTurmas { get; set; } = new();

        #endregion
    }
}
