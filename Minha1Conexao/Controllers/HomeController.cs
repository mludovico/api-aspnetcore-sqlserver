using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Interface;
using Minha1Conexao.Domain.Model;
using Minha1Conexao.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minha1Conexao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuarioDto)
        {
            try
            {
                if(string.IsNullOrEmpty(usuarioDto.Nome) || string.IsNullOrEmpty(usuarioDto.Senha))
                {
                    return BadRequest("Você deve prover um nome e uma senha");
                }
                var usuario = _usuarioRepository.SelecionarPorNomeESenha(usuarioDto.Nome, usuarioDto.Senha);
                if(usuario == null)
                {
                    return NotFound("Nome e/ou senha não encontrados");
                }
                var token = TokenService.GerarToken(usuario);
                return Ok(token);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um problema");
                throw;
            }
        }
    }
}
