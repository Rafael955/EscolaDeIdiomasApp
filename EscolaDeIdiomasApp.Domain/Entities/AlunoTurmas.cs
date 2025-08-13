using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Entities
{
    public class AlunoTurmas
    {
        public Guid IdAluno { get; set; }
        public Aluno? Aluno { get; set; }

        public Guid IdTurma { get; set; }
        public Turma? Turma { get; set; }
    }
}
