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
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();

        }

        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Inscrever(presencaEvento);

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
                return Ok(_presencaEventoRepository.Listar());
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
                _presencaEventoRepository.Deletar(id);

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
                return Ok(_presencaEventoRepository.BuscarPorId(id));


            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Atualizar(id,presencaEvento);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }


        }
    }
}
