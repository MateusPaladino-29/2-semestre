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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _TipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _TipoEventoRepository = new TipoEventoRepository();

        }

        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _TipoEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar evento");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_TipoEventoRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _TipoEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_TipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(TipoEvento tipoEvento, Guid id) 
        {
            try
            {
                _TipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Atualizar");
            }
        }
    }
}
