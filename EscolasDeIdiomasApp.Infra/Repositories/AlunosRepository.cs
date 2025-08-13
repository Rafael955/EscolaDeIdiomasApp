using EscolaDeIdiomasApp.Domain.Entities;
using EscolaDeIdiomasApp.Domain.Interfaces.Repositories;
using EscolasDeIdiomasApp.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EscolasDeIdiomasApp.Infra.Repositories
{
    public class AlunosRepository : IAlunosRepository
    {
        public void Add(Aluno aluno)
        {
            using (var context = new DataContext())
            {
                context.Add(aluno);
                context.SaveChanges();
            }
        }

        public void Update(Aluno aluno)
        {
            using (var context = new DataContext())
            {
                context.Update(aluno);
                context.SaveChanges();
            }
        }

        public void Delete(Aluno aluno)
        {
            using (var context = new DataContext())
            {
                context.Remove(aluno);
                context.SaveChanges();
            }
        }

        public Aluno? GetById(Guid? id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Aluno>()
                    .Include(a => a.AlunoTurmas)
                    .ThenInclude(x => x.Turma)
                    .SingleOrDefault(a => a.Id == id);
            }
        }

        public List<Aluno>? GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Aluno>()
                    .AsNoTracking()
                    .ToList();
            }
        }

        public bool CPFAlreadyExistsInDatabase(string cpf, out Aluno? alunoComCPF)
        {
            using (var context = new DataContext())
            {
                alunoComCPF = context.Set<Aluno>().SingleOrDefault(a => a.CPF == cpf);

                return context.Set<Aluno>().Any(a => a.CPF == cpf);
            }
        }
    }
}
