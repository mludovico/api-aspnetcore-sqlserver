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
    public class AlunoController : ControllerBase
    {
        private AlunoRepository repo = new AlunoRepository();
        // GET: api/<AlunoController>
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IEnumerable<Aluno> Post([FromBody] Aluno aluno)
        {
            repo.Incluir(aluno);
            return repo.SelecionarTudo();
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IEnumerable<Aluno> Put(int id, [FromBody] Aluno aluno)
        {
            repo.Alterar(aluno);
            return repo.SelecionarTudo();
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
