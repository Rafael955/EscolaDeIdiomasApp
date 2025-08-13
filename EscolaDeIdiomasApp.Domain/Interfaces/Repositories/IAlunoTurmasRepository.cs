using EscolaDeIdiomasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Interfaces.Repositories
{
    public interface IAlunoTurmasRepository
    {
        void Add(AlunoTurmas alunoTurma);

        void Update(AlunoTurmas alunoTurma);

        void Delete(AlunoTurmas alunoTurma);

        List<AlunoTurmas>? GetByStudentId(Guid alunoId);

        List<AlunoTurmas>? GetByClassId(Guid turmaId);

        List<AlunoTurmas>? GetAll();

        bool VerifyIfStudentIsAlreadySubscribedToClass(Guid alunoId, Guid turmaId);

        bool VerifyIfClassIsAlreadyFull(Guid turmaId);
    }
}
