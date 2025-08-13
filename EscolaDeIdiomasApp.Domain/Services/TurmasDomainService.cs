using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using EscolaDeIdiomasApp.Domain.Entities;
using EscolaDeIdiomasApp.Domain.Enums;
using EscolaDeIdiomasApp.Domain.Helpers;
using EscolaDeIdiomasApp.Domain.Interfaces.Repositories;
using EscolaDeIdiomasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Services
{
    public class TurmasDomainService(ITurmasRepository turmasRepository, IAlunoTurmasRepository alunoTurmasRepository) : ITurmasDomainService
    {
        public TurmaResponseDto CriarTurma(TurmaRequestDto request)
        {
            Turma? turma;
            string errors = string.Empty;

            if (!RequestValidationHelper.IsRequestValidationsOk(request, out errors))
                throw new ValidationException($"{errors}");

            if (turmasRepository.ClassNumberAlreadyExists(request.Numero, out turma))
                throw new ApplicationException($"Já existe uma turma cadastrada com este número!");

            turma = new Turma
            {
                Numero = request.Numero,
                Ano = request.Ano,
                NivelTurma = (NivelTurma)request.NivelTurma
            };

            turmasRepository.Add(turma);

            turma = turmasRepository.GetById(turma.Id);

            return ToResponse(turma);
        }

        public TurmaResponseDto AtualizarTurma(Guid id, TurmaRequestDto request)
        {
            string errors = string.Empty;

            Turma? turma = turmasRepository.GetById(id);

            if (turma == null)
                throw new ApplicationException($"A turma não pôde ser encontrada!");

            if (!RequestValidationHelper.IsRequestValidationsOk(request, out errors))
                throw new ValidationException($"{errors}");

            if (turmasRepository.ClassNumberAlreadyExists(request.Numero, out turma) && turma != null && turma.Id != id)
                throw new ApplicationException($"Já existe uma turma cadastrada com este número!");

            turma = new Turma
            {
                Numero = request.Numero,
                Ano = request.Ano,
                NivelTurma = (NivelTurma)request.NivelTurma
            };

            turmasRepository.Add(turma);

            turma = turmasRepository.GetById(turma.Id);

            return ToResponse(turma);
        }

        public TurmaResponseDto ExcluirTurma(Guid id)
        {
            Turma? turma = turmasRepository.GetById(id);

            if (turma == null)
                throw new ApplicationException($"A turma não pôde ser encontrada!");

            if (alunoTurmasRepository.GetByClassId(id)?.Count > 0)
                throw new ApplicationException($"A turma não poderá ser excluida pois ainda há alunos associados a mesma!");

            turmasRepository.Delete(turma);

            return ToResponse(turma);
        }

        public TurmaResponseDto ObterTurmaPorId(Guid id)
        {
            Turma? turma = turmasRepository.GetById(id);

            if (turma == null)
                throw new ApplicationException($"A turma não pôde ser encontrada!");

            return ToResponse(turma); 
        }

        public List<TurmaResponseDto>? ListarTurmas()
        {
            List<Turma>? listaTurmas = turmasRepository.GetAll();

            List<TurmaResponseDto>? _listaTurmas = new List<TurmaResponseDto>();

            foreach (var turma in listaTurmas)
            {
                _listaTurmas.Add(ToResponse(turma));
            }

            return _listaTurmas;
        }

        private TurmaResponseDto ToResponse(Turma turma)
        {
            var response = new TurmaResponseDto
            {
                Id = turma.Id,
                Numero = turma.Numero,
                Ano = turma.Ano,
                NivelTurma = new NivelTurmaDto
                {
                    Codigo = (int)turma.NivelTurma,
                    Descricao = turma.NivelTurma.ToString()
                }
            };

            if (turma.AlunoTurmas?.Count > 0)
            {
                foreach (var aluno in turma.AlunoTurmas)
                {
                    response.Alunos.Add(new AlunoResponseDto
                    {
                        Id = aluno.Aluno.Id,
                        Nome = aluno.Aluno.Nome,
                        CPF = aluno.Aluno.CPF,
                        Email = aluno.Aluno.Email
                    });
                }
            }

            return response;
        }
    }
}
