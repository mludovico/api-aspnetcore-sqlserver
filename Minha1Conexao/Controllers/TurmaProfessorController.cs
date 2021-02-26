using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Repository;
using Minha1Conexao.Domain;
using Minha1Conexao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minha1Conexao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaProfessorController : ControllerBase
    {
        private TurmaProfessorRepository repo = new TurmaProfessorRepository();
        // GET: api/<TurmaProfessorController>
        [HttpGet]
        public IEnumerable<TurmaProfessor> Get()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<TurmaProfessorController>/5
        [HttpGet("{id}")]
        public TurmaProfessor Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<TurmaProfessorController>
        [HttpPost]
        public IEnumerable<TurmaProfessor> Post([FromBody] TurmaProfessor turmaProfessor)
        {
            repo.Incluir(turmaProfessor);
            return repo.SelecionarTudo();
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut]
        public IEnumerable<TurmaProfessor> Put(int id, [FromBody] TurmaProfessor turmaProfessor)
        {
            repo.Alterar(turmaProfessor);
            return repo.SelecionarTudo();
        }

        // DELETE api/<TurmaProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
