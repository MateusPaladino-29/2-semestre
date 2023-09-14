using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Repository;

namespace webapi.inlock_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    public class UsuarioController : ControllerBase
    {
        

        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar");
            }

        }

    }
}
