using Minha1Conexao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minha1Conexao.Data.Repository
{
    public class ProfessorRepository
    {
        private readonly Context context;
        public ProfessorRepository()
        {
            context = new Context();
        }

        public void Incluir(Professor professor)
        {
            context.Professor.Add(professor);
            context.SaveChanges();
        }

        public Professor Selecionar(int id) => context.Professor.FirstOrDefault(x => x.Id == id);

        public void Alterar(Professor professor)
        {
            context.Professor.Update(professor);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var professor = Selecionar(id);
            context.Professor.Remove(professor);
            context.SaveChanges();
        }

        public List<Professor> SelecionarTudo() => context.Professor.ToList();
    }
}
