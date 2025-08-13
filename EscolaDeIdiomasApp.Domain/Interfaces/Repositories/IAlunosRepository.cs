using EscolaDeIdiomasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaDeIdiomasApp.Domain.Interfaces.Repositories
{
    public interface IAlunosRepository
    {
        void Add(Aluno aluno);
        
        void Update(Aluno aluno);
        
        void Delete(Aluno aluno);

        Aluno? GetById(Guid? id);

        List<Aluno>? GetAll();

        bool CPFAlreadyExistsInDatabase(string cpf, out Aluno? alunoComCPF);
    }
}
