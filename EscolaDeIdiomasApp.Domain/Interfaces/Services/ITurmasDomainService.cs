using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;

namespace EscolaDeIdiomasApp.Domain.Interfaces.Services
{
    public interface ITurmasDomainService
    {
        TurmaResponseDto CriarTurma(TurmaRequestDto request);

        TurmaResponseDto AtualizarTurma(Guid id, TurmaRequestDto request);

        TurmaResponseDto ExcluirTurma(Guid id);

        TurmaResponseDto ObterTurmaPorId(Guid id);

        List<TurmaResponseDto>? ListarTurmas();
    }
}
