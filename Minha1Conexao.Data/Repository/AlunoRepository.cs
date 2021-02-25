using Minha1Conexao.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Minha1Conexao.Data.Repository
{
    public class AlunoRepository
    {
        private readonly Context context;
        public AlunoRepository()
        {
            context = new Context();
        }

        public void Incluir(Aluno aluno)
        {
            context.Aluno.Add(aluno);
            context.SaveChanges();
        }

        public Aluno Selecionar(int id) => context.Aluno.FirstOrDefault(x => x.Id == id);

        public void Alterar(Aluno aluno)
        {
            context.Aluno.Update(aluno);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var aluno = Selecionar(id);
            context.Aluno.Remove(aluno);
            context.SaveChanges();
        }

        public List<Aluno> SelecionarTudo() => context.Aluno.ToList();
    }
}
