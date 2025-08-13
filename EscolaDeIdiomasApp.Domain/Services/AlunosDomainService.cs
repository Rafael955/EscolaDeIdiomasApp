using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using EscolaDeIdiomasApp.Domain.Interfaces.Services;
using EscolaDeIdiomasApp.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscolaDeIdiomasApp.Domain.Interfaces.Repositories;
using EscolaDeIdiomasApp.Domain.Entities;

namespace EscolaDeIdiomasApp.Domain.Services
{
    public class AlunosDomainService(IAlunosRepository alunosRepository, IAlunoTurmasRepository alunoTurmasRepository, ITurmasRepository turmasRepository) : IAlunosDomainService
    {
        public AlunoResponseDto CriarAluno(CadastrarAlunoRequestDto request)
        {
            Aluno? aluno;
            string errors = string.Empty;

            if (!RequestValidationHelper.IsRequestValidationsOk(request, out errors))
                throw new ValidationException($"{errors}");

            if (alunosRepository.CPFAlreadyExistsInDatabase(request.CPF, out aluno))
                throw new ApplicationException("O CPF informado já está cadastrado para outro aluno.");

            foreach (var idTurma in request.IdTurmas)
            {
                if(turmasRepository.GetById(idTurma) == null)
                    throw new ApplicationException($"O id '{idTurma}' informado para uma turma não foi encontrado!");
                
                Turma? turma = turmasRepository.GetById(idTurma);

                if (alunoTurmasRepository.VerifyIfClassIsAlreadyFull(idTurma))
                    throw new ApplicationException($"O aluno {aluno.Nome} não poderá se matricular na turma {turma.Numero} pois ela já está cheia.");
            }

            aluno = new Aluno
            {
                Nome = request.Nome,
                CPF = request.CPF,
                Email = request.Email
            };

            alunosRepository.Add(aluno);

            foreach (var idTurma in request.IdTurmas)
            {
                var alunoTurma = new AlunoTurmas
                {
                    IdAluno = aluno.Id,
                    IdTurma = idTurma
                };

                alunoTurmasRepository.Add(alunoTurma);
            }

            aluno = alunosRepository.GetById(aluno.Id);

            return ToResponse(aluno);
        }

        public AlunoResponseDto AtualizarAluno(Guid id, AtualizarAlunoRequestDto request)
        {
            string errors = string.Empty;

            Aluno? aluno = alunosRepository.GetById(id);

            if (aluno == null)
                throw new ApplicationException($"O aluno não pode ser encontrado!");

            if (!RequestValidationHelper.IsRequestValidationsOk(request, out errors))
                throw new ValidationException($"Erros de validação: {errors}");

            if (alunosRepository.CPFAlreadyExistsInDatabase(request.CPF, out aluno) && aluno.Id != id)
                throw new ApplicationException("O CPF informado já está cadastrado para outro aluno.");

            aluno.Nome = request.Nome;
            aluno.CPF = request.CPF;
            aluno.Email = request.Email;

            alunosRepository.Update(aluno);

            aluno = alunosRepository.GetById(aluno.Id);

            return ToResponse(aluno);

        }

        public AlunoResponseDto ExcluirAluno(Guid id)
        {
            Aluno? aluno = alunosRepository.GetById(id);

            if (aluno == null)
                throw new ApplicationException($"O aluno não pode ser encontrado!");

            if (alunoTurmasRepository.GetByStudentId(id)!?.Count > 0)
                throw new ApplicationException("Não é possível excluir o aluno pois o mesmo ainda está cadastrado em 1 ou mais turmas");

            var alunoTurmas = alunoTurmasRepository.GetByStudentId(aluno.Id);

            foreach (var alunoTurma in alunoTurmas)
            {
                alunoTurmasRepository.Delete(alunoTurma);
            }

            alunosRepository.Delete(aluno);

            return ToResponse(aluno);
        }

        public AlunoResponseDto ObterAlunoPorId(Guid id)
        {
            Aluno? aluno = alunosRepository.GetById(id);

            if (aluno == null)
                throw new ApplicationException($"O aluno não pode ser encontrado!");

            return ToResponse(aluno);
        }

        public List<AlunoResponseDto>? ListarAlunos()
        {
            List<Aluno>? listaAlunos = alunosRepository.GetAll();

            if (listaAlunos == null || listaAlunos.Count == 0)
                throw new ApplicationException("Nenhum aluno foi encontrado!");

            List<AlunoResponseDto> listaAlunosDto = new List<AlunoResponseDto>();

            foreach (var aluno in listaAlunos)
            {
                listaAlunosDto.Add(ToResponse(aluno));
            }

            return listaAlunosDto;
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
