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
        [Range(1, 9999, ErrorMessage = "O número da turma deverá ser entre 1 e 9999.")]
        public required int Numero { get; set; }

        [Required(ErrorMessage = "O ano da turma é obrigatório.")]
        [Range(1950, 2150, ErrorMessage = "O ano da turma deverá ser entre 1950 e 2150.")]
        public required int Ano { get; set; }

        [Required(ErrorMessage = "O nível da turma é obrigatório.")]
        public required int NivelTurma { get; set; }
    }
}
