using Minha1Conexao.Data.Interface;
using Minha1Conexao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minha1Conexao.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }
    }
}
