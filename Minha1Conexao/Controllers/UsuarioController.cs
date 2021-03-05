using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Interface;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.SelecionarTudo());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _repo.Incluir(usuario);
                return Ok("Usuário criado com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
