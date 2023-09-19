using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Repository;
using webapi.inlock_codefirst.ViewModels;

namespace webapi.inlock_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();

        }

        [HttpPost]
         public IActionResult Login(LoginViewModel usuario)     
         {
             try
             {
                  UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email!, usuario.Senha!);

                 if (usuarioBuscado == null)
                 {
                     return StatusCode(401, "Email ou senha Invalido");
                 }
             }
             catch (Exception)
             {

                 throw new Exception("Erro na senha ou no Email");
             }
         }
    
    }
}
