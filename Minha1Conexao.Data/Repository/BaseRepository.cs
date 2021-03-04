using System.Collections.Generic;
using System.Linq;
using Minha1Conexao.Domain;

namespace Minha1Conexao.Data.Repository
{
    public class BaseRepository<T> where T: class, IEntity
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public virtual void Incluir(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public List<T> SelecionarTudo()
        {
            return _context.Set<T>().ToList();
        }

        public T Selecionar(int id)
        {
            return _context.Set<T>().Where<T>(x => x.Id == id).FirstOrDefault();
        }

        public void Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Excluir(int id)
        {
            var entity = Selecionar(id);
            _context.Set<T>().Remove(entity);
        }

        public void Dispose() => _context.Dispose();
    }
}
