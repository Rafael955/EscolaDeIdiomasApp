using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.DTOs.Request
{
    public class TurmaRequestDto
    {
        [Required(ErrorMessage = "O número da turma é obrigatório.")]
        public required int Numero { get; set; }

        [Required(ErrorMessage = "O ano da turma é obrigatório.")]
        public required int Ano { get; set; }

        [Required(ErrorMessage = "O nível da turma é obrigatório.")]
        public required int NivelTurma { get; set; }
    }
}
