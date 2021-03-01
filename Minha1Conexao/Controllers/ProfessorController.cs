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
    public class ProfessorController : ControllerBase
    {
        private IProfessorRepository _repo;

        public ProfessorController(IProfessorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public Professor Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IEnumerable<Professor> Post([FromBody] Professor professor)
        {
            _repo.Incluir(professor);
            return _repo.SelecionarTudo();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IEnumerable<Professor> Put(int id, [FromBody] Professor professor)
        {
            _repo.Alterar(professor);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Professor> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
