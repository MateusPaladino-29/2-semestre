using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repository;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();

        }
        [HttpPost]
        public IActionResult Post(Usuario Usuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(Usuario);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar a rota");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_UsuarioRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Listar");
            }

        }

        [HttpPut("{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_UsuarioRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a Rota de Buscar por Id");
            }
        }

        /*[HttpGet]
        public IActionResult Get()
        {
            try
            {
                Usuario usuarioBuscado = _UsuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha Invalido");
                }
            }
            catch (Exception)
            {

                throw new Exception("Erro na senha ou no Email");
            }   

        }*/
    }
}
