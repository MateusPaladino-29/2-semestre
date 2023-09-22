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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; }

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar");
            }

        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_eventoRepository.Listar());
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
                _eventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Error ao deletar Evento"); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));   
            }
            catch (Exception)
            {

                throw new Exception("Erro ao busca por Id");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Evento evento, Guid Id) 
        {
            try
            {
                _eventoRepository.Atualizar(Id, evento);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Atualizar");
            }
              
        }
    }
}
