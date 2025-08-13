using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.DTOs.Response
{
    public class TurmaResponseDto
    {
        public Guid Id { get; set; }

        public int Numero { get; set; }

        public int Ano { get; set; }

        public NivelTurmaDto NivelTurma { get; set; }

        public List<AlunoResponseDto>? Alunos { get; set; } = new();
    }
}
