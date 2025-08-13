using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Interfaces.Services
{
    public interface IAlunoTurmasDomainService
    {
        AlunoResponseDto MatricularAlunoEmTurma(Guid idAluno, AlunoTurmasRequestDto request);

        AlunoResponseDto RemoverAlunoDaTurma(Guid idAluno, AlunoTurmasRequestDto request);
    }
}
