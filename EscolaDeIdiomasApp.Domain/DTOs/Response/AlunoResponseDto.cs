using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.DTOs.Response
{
    public class AlunoResponseDto
    {
        public Guid Id { get; set; }

        public string? Nome { get; set; }

        public string? CPF { get; set; }

        public string? Email { get; set; }

        public List<TurmaResponseDto>? Turmas { get; set; } = new();
    }
}
