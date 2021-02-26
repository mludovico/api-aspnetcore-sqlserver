using System;
using System.Collections.Generic;
using System.Text;

namespace Minha1Conexao.Domain.Model
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<TurmaProfessor> TurmaProfessor { get; set; }
    }
}
