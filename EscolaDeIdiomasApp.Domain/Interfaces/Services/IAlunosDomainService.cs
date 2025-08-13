using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Interfaces.Services
{
    public interface IAlunosDomainService
    {
        AlunoResponseDto CriarAluno(CadastrarAlunoRequestDto request);

        AlunoResponseDto AtualizarAluno(Guid idAluno, AtualizarAlunoRequestDto request);

        AlunoResponseDto ExcluirAluno(Guid idAluno);

        AlunoResponseDto ObterAlunoPorId(Guid idAluno);

        List<AlunoResponseDto>? ListarAlunos();
    }
}
