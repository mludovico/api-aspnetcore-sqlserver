using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Interface;
using Minha1Conexao.Data.Repository;
using Minha1Conexao.Domain.Model;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minha1Conexao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private ITurmaRepository _repo;

        public TurmaController(ITurmaRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<TurmaController>
        [HttpGet]
        public IEnumerable<Turma> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IEnumerable<Turma> Post([FromBody] Turma turma)
        {
            _repo.Incluir(turma);
            return _repo.SelecionarTudo();
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public IEnumerable<Turma> Put(int id, [FromBody] Turma turma)
        {
            _repo.Alterar(turma);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Excluir(id);
        }
    }
}
