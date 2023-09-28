using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository _AgendamentoRepository { get; set; }

        public AgendamentoController()
        {
            _AgendamentoRepository = new Repository.AgendamentoRepository();

        }

        [HttpPost]
        public IActionResult Post(Agendamento agendamento)
        {
            try
            {
                _AgendamentoRepository.(agendamento);

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
                return Ok(_AgendamentoRepository.Listar());
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
                _AgendamentoRepository.Deletar(id);

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
                return Ok(_AgendamentoRepository.BuscarPorId(id));


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
                _AgendamentoRepository.Atualizar(id, tipousuario);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }


        }
    }
}
