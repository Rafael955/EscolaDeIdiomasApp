using EscolaDeIdiomasApp.Domain.Entities;
using EscolaDeIdiomasApp.Domain.Interfaces.Repositories;
using EscolasDeIdiomasApp.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolasDeIdiomasApp.Infra.Repositories
{
    public class AlunoTurmasRepository : IAlunoTurmasRepository
    {
        public void Add(AlunoTurmas alunoTurma)
        {
            using (var context = new DataContext())
            {
                context.Add(alunoTurma);
                context.SaveChanges();
            }
        }

        public void Update(AlunoTurmas alunoTurma)
        {
            using (var context = new DataContext())
            {
                context.Update(alunoTurma);
                context.SaveChanges();
            }
        }

        public void Delete(AlunoTurmas alunoTurma)
        {
            using (var context = new DataContext())
            {
                context.Remove(alunoTurma);
                context.SaveChanges();
            }
        }

        public List<AlunoTurmas>? GetByStudentId(Guid alunoId)
        {
            using (var context = new DataContext())
            {
                return context.Set<AlunoTurmas>()
                    .Where(at => at.IdAluno == alunoId)
                    .ToList();
            }
        }

        public List<AlunoTurmas>? GetByClassId(Guid turmaId)
        {
            using (var context = new DataContext())
            {
                return context.Set<AlunoTurmas>()
                    .Where(at => at.IdTurma == turmaId)
                    .ToList();
            }
        }

        public List<AlunoTurmas>? GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<AlunoTurmas>()
                    .ToList();
            }
        }

        public bool VerifyIfStudentIsAlreadySubscribedToClass(Guid alunoId, Guid turmaId)
        {
            using (var context = new DataContext())
            {
                return context.Set<AlunoTurmas>()
                    .Any(at => at.IdAluno == alunoId && at.IdTurma == turmaId);
            }
        }

        public bool VerifyIfClassIsAlreadyFull(Guid turmaId)
        {
            using (var context = new DataContext())
            {
                return context.Set<AlunoTurmas>().Where(at => at.IdTurma == turmaId).ToList()
                      .Count() == 5;
            }
        }

    }
}
