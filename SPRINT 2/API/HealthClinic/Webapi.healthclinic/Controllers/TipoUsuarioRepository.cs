using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;
using Webapi.healthclinic.Repository;

namespace Webapi.healthclinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioRepository : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioRepository()
        {
            _TipoUsuarioRepository = new Repository.TipoUsuarioRepository();

        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _TipoUsuarioRepository.Cadastrar(tipoUsuario);

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
                    return Ok(_TipoUsuarioRepository.Listar());
                }
                catch (Exception)
                {

                    throw new Exception("Error ao Listar");
                }
            }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _TipoUsuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpGet("{Id}")]
        public IActionResult GetbyId(Guid id)
        {
            try
            {
                return Ok(_TipoUsuarioRepository.BuscarPorId(id));


            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tipousuario)
        {
            try
            {
                _TipoUsuarioRepository.Atualizar(id, tipousuario);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }


        }
    }
}
