using System.Collections.Generic;
using System.Linq;
using Minha1Conexao.Domain;

namespace Minha1Conexao.Data.Repository
{
    public class BaseRepository<T> where T: class, IEntity
    {
        protected Context context;
        public void Incluir(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public List<T> SelecionarTudo()
        {
            return context.Set<T>().ToList();
        }

        public T Selecionar(int id)
        {
            return context.Set<T>().Where<T>(x => x.Id == id).FirstOrDefault();
        }

        public void Alterar(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Excluir(int id)
        {
            var entity = Selecionar(id);
            context.Set<T>().Remove(entity);
        }

        public void Dispose() => context.Dispose();
    }
}
