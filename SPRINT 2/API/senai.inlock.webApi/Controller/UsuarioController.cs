using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository  = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioDomain = _UsuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválidos!");
                }

                //Caso encontre o usuário buscado, prossegue para a criação do Token

                //1º - Definir as informações(Claims) que serão fornecidos no token (Payload)
                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString()),
                   

                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada", "Valor Personalizado")
                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Jogo-chave-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar o token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.senai.inlock",

                    //destinatário do token
                    audience: "webapi.senai.inlock",

                    //dados definidos nas claims (Payload)
                    claims: claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //5º - retornar o token criado

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }
    }
}
