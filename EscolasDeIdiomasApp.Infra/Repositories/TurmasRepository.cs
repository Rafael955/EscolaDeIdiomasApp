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
    public class TurmasRepository : ITurmasRepository
    {
        public void Add(Turma turma)
        {
            using (var context = new DataContext())
            {
                context.Add(turma);
                context.SaveChanges();
            }
        }

        public void Update(Turma turma)
        {
            using (var context = new DataContext())
            {
                context.Update(turma);
                context.SaveChanges();
            }
        }

        public void Delete(Turma turma)
        {
            using (var context = new DataContext())
            {
                context.Remove(turma);
                context.SaveChanges();
            }
        }

        public Turma? GetById(Guid? id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Turma>()
                    .Include(t => t.AlunoTurmas)
                    .ThenInclude(x => x.Aluno)
                    .SingleOrDefault(t => t.Id == id);
            }
        }

        public List<Turma>? GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Turma>()
                    .AsNoTracking()
                    .ToList();
            }
        }

        public bool ClassNumberAlreadyExists(int classNumber, out Turma? turmaComNumero)
        {
            using (var context = new DataContext())
            {
                turmaComNumero = context.Set<Turma>()
                    .SingleOrDefault(t => t.Numero == classNumber);

                return context.Set<Turma>()
                    .Any(t => t.Numero == classNumber);
            }
        }
    }
}
