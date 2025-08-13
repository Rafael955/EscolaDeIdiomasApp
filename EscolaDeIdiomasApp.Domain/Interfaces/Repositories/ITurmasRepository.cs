using EscolaDeIdiomasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Interfaces.Repositories
{
    public interface ITurmasRepository
    {
        void Add(Turma turma);

        void Update(Turma turma);

        void Delete(Turma turma);

        Turma? GetById(Guid? id);

        List<Turma>? GetAll();

        bool ClassNumberAlreadyExists(int classNumber, out Turma? turmaComNumero);
    }
}
