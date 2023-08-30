using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                
                UsuarioDomain usuarioDomain = _UsuarioRepository.Login(email, senha);

                if (usuarioDomain != null)
                {
                    
                    return Ok(usuarioDomain);
                }
                else
                {
                    
                    return Unauthorized();
                }
            }
            catch (Exception erro)
            {
                
                return BadRequest(erro.Message);
            }
        }
    }
}

//feito com  documentação 