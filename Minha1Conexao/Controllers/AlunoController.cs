using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Interface;
using Minha1Conexao.Data.Repository;
using Minha1Conexao.Domain;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minha1Conexao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repo;

        public AlunoController(IAlunoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<AlunoController>
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IEnumerable<Aluno> Post([FromBody] Aluno aluno)
        {
            _repo.Incluir(aluno);
            return _repo.SelecionarTudo();
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IEnumerable<Aluno> Put(int id, [FromBody] Aluno aluno)
        {
            _repo.Alterar(aluno);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Excluir(id);
        }
    }
}
