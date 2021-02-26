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
    public class TurmaController : ControllerBase
    {
        private TurmaRepository repo = new TurmaRepository();
        // GET: api/<TurmaController>
        [HttpGet]
        public IEnumerable<Turma> Get()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IEnumerable<Turma> Post([FromBody] Turma turma)
        {
            repo.Incluir(turma);
            return repo.SelecionarTudo();
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public IEnumerable<Turma> Put(int id, [FromBody] Turma turma)
        {
            repo.Alterar(turma);
            return repo.SelecionarTudo();
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
