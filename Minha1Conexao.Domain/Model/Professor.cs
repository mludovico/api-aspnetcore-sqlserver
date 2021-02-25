using System;
using System.Collections.Generic;
using System.Text;

namespace Minha1Conexao.Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Turno Turno { get; set; }
    }

    public enum Turno{
        Manha,
        Tarde,
        Noite
    }
}
