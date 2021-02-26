using System;
using System.Collections.Generic;
using System.Text;

namespace Minha1Conexao.Domain.Model
{
    public class TurmaProfessor
    {
        public int Id { get; set; }
        public int IdProfessor { get; set; }
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
        public Professor Professor { get; set; }
    }
}
