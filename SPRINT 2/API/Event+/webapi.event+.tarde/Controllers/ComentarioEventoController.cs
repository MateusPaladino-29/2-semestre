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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioRepository _ComentarioRepository { get; set; }

        public ComentarioEventoController()
        {
            _ComentarioRepository = new ComentarioRepository();

        }

        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _ComentarioRepository.Cadastrar(comentarioEvento);

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
                return Ok(_ComentarioRepository.Listar());
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
                _ComentarioRepository.Deletar(id);

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
                return Ok(_ComentarioRepository.BuscarPorId(id));


            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }
    }
}
