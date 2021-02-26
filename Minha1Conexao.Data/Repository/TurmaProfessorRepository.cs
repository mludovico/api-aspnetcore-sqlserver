using Minha1Conexao.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Minha1Conexao.Data.Repository
{
    public class TurmaProfessorRepository
    {
        private readonly Context context;
        public TurmaProfessorRepository()
        {
            context = new Context();
        }

        public void Incluir(TurmaProfessor turmaProfessor)
        {
            context.TurmaProfessor.Add(turmaProfessor);
            context.SaveChanges();
        }

        public TurmaProfessor Selecionar(int id) => context.TurmaProfessor.FirstOrDefault(x => x.Id == id);

        public void Alterar(TurmaProfessor turmaProfessor)
        {
            context.TurmaProfessor.Update(turmaProfessor);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var turmaProfessor = Selecionar(id);
            context.TurmaProfessor.Remove(turmaProfessor);
            context.SaveChanges();
        }

        public List<TurmaProfessor> SelecionarTudo() => context.TurmaProfessor.ToList();
    }
}
