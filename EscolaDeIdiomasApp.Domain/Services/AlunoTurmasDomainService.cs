using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using EscolaDeIdiomasApp.Domain.Entities;
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
    public class AlunoTurmasDomainService(IAlunosRepository alunosRepository, IAlunoTurmasRepository alunoTurmasRepository, ITurmasRepository turmasRepository) : IAlunoTurmasDomainService
    {
        public AlunoResponseDto MatricularAlunoEmTurma(Guid idAluno, AlunoTurmasRequestDto request)
        {
            string errors = string.Empty;

            if (!RequestValidationHelper.IsRequestValidationsOk(request, out errors))
                throw new ValidationException($"Erros de validação: {errors}");

            var aluno = alunosRepository.GetById(idAluno);

            if (aluno == null)
                throw new ApplicationException($"O aluno não pode ser encontrado!");

            var turma = turmasRepository.GetById(request.IdTurma);

            if (turma == null)
                throw new ApplicationException($"A turma não pode ser encontrada!");

            if (alunoTurmasRepository.VerifyIfStudentIsAlreadySubscribedToClass(idAluno, request.IdTurma))
                throw new ApplicationException($"O aluno {aluno.Nome} já está matriculado para esta turma.");

            if (alunoTurmasRepository.VerifyIfClassIsAlreadyFull(request.IdTurma))
                throw new ApplicationException($"O aluno {aluno.Nome} não poderá se matricular na turma {turma.Numero} pois ela já está cheia.");

            AlunoTurmas? alunoTurmas = new AlunoTurmas
            {
                IdAluno = idAluno,
                IdTurma = request.IdTurma
            };

            alunoTurmasRepository.Add(alunoTurmas);

            aluno = alunosRepository.GetById(idAluno);

            return ToResponse(aluno);
        }

        public AlunoResponseDto RemoverAlunoDaTurma(Guid idAluno, AlunoTurmasRequestDto request)
        {
            string errors = string.Empty;

            if (!RequestValidationHelper.IsRequestValidationsOk(request, out errors))
                throw new ValidationException($"Erros de validação: {errors}");

            var aluno = alunosRepository.GetById(idAluno);

            if (aluno == null)
                throw new ApplicationException($"O aluno não pode ser encontrado!");

            var turma = turmasRepository.GetById(request.IdTurma);

            if (turma == null)
                throw new ApplicationException($"A turma não pode ser encontrada!");

            AlunoTurmas? alunoTurmas = new AlunoTurmas
            {
                IdAluno = idAluno,
                IdTurma = request.IdTurma
            };

            alunoTurmasRepository.Delete(alunoTurmas);

            aluno = alunosRepository.GetById(idAluno);

            return ToResponse(aluno);
        }

        private AlunoResponseDto ToResponse(Aluno aluno)
        {
            var response = new AlunoResponseDto
            {
                Id = aluno.Id,
                CPF = aluno.CPF,
                Email = aluno.Email,
                Nome = aluno.Nome
            };

            if (aluno.AlunoTurmas.Count > 0)
            {
                foreach (var turma in aluno.AlunoTurmas)
                {
                    response.Turmas.Add(new TurmaResponseDto
                    {
                        Id = turma.Turma.Id,
                        Ano = turma.Turma.Ano,
                        NivelTurma = new NivelTurmaDto
                        {
                            Codigo = (int)turma.Turma.NivelTurma,
                            Descricao = turma.Turma.NivelTurma.ToString()
                        },
                        Numero = turma.Turma.Numero
                    });
                }
            }

            return response;
        }
    }
}
