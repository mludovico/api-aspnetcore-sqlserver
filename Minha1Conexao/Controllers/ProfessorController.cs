using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Repository;
using Minha1Conexao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minha1Conexao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private ProfessorRepository repo = new ProfessorRepository();
        // GET: api/<ProfessorController>
        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public Professor Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IEnumerable<Professor> Post([FromBody] Professor professor)
        {
            repo.Incluir(professor);
            return repo.SelecionarTudo();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IEnumerable<Professor> Put(int id, [FromBody] Professor professor)
        {
            repo.Alterar(professor);
            return repo.SelecionarTudo();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Professor> Delete(int id)
        {
            repo.Excluir(id);
            return repo.SelecionarTudo();
        }
    }
}
