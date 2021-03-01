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
    public class TurmaProfessorController : ControllerBase
    {
        private ITurmaProfessorRepository _repo;

        public TurmaProfessorController(ITurmaProfessorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<TurmaProfessorController>
        [HttpGet]
        public IEnumerable<TurmaProfessor> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<TurmaProfessorController>/5
        [HttpGet("{id}")]
        public TurmaProfessor Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<TurmaProfessorController>
        [HttpPost]
        public IEnumerable<TurmaProfessor> Post([FromBody] TurmaProfessor turmaProfessor)
        {
            _repo.Incluir(turmaProfessor);
            return _repo.SelecionarTudo();
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut]
        public IEnumerable<TurmaProfessor> Put(int id, [FromBody] TurmaProfessor turmaProfessor)
        {
            _repo.Alterar(turmaProfessor);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<TurmaProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Excluir(id);
        }
    }
}
