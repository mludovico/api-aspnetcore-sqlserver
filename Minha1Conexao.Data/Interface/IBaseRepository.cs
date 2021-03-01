using Minha1Conexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minha1Conexao.Data
{
    public interface IBaseRepository<T> where T: class, IEntity
    {
        public void Incluir(T entity);
        public List<T> SelecionarTudo();
        public T Selecionar(int id);
        public void Alterar(T entity);
        public void Excluir(int id);
        public void Dispose();
    }
}
