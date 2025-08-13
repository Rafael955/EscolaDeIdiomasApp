using EscolaDeIdiomasApp.Domain.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeIdiomasApp.Domain.DTOs.Request
{
    public class AtualizarAlunoRequestDto
    {
        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome do aluno deverá ter no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "O nome do aluno deverá ter no máximo {1} caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O CPF do aluno é obrigatório.")]
        [Length(11, 11, ErrorMessage = "O CPF deverá ter 11 caracteres.")]
        [Cpf(ErrorMessage = "O CPF informado é inválido.")]
        public required string CPF { get; set; }

        [Required(ErrorMessage = "O Email do aluno é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email informado está em um formato inválido.")]
        [MaxLength(100, ErrorMessage = "O Email deverá ter no máximo {1} caracteres.")]
        public required string Email { get; set; }
    }
}