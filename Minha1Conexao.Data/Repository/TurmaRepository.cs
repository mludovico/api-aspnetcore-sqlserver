using Minha1Conexao.Domain;
using Minha1Conexao.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Minha1Conexao.Data.Repository
{
    public class TurmaRepository
    {
        private readonly Context context;
        public TurmaRepository()
        {
            context = new Context();
        }

        public void Incluir(Turma turma)
        {
            context.Turma.Add(turma);
            context.SaveChanges();
        }

        public Turma Selecionar(int id) => context.Turma.FirstOrDefault(x => x.Id == id);

        public void Alterar(Turma turma)
        {
            context.Turma.Update(turma);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var turma = Selecionar(id);
            context.Turma.Remove(turma);
            context.SaveChanges();
        }

        public List<Turma> SelecionarTudo() => context.Turma.ToList();
    }
}
