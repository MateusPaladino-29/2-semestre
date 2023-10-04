using Microsoft.AspNetCore.Authorization;
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
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository _AgendamentoRepository;

        public AgendamentoController()
        {
            _AgendamentoRepository = new AgendamentoRepository();

        }

        [Authorize("Administrador")]
        [HttpPost]
        public IActionResult Post(Agendamento agendamento)
        {
            try
            {
                _AgendamentoRepository.Cadastrar(agendamento);

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

        /* [Authorize("Administrador")]*/
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

        /* [Authorize("Administrador")]*/
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Agendamento agendamento)
        {
            try
            {
                _AgendamentoRepository.Atualizar(id, agendamento);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }


        }
    }
}
