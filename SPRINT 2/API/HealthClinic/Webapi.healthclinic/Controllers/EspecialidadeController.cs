using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _EspecialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _EspecialidadeRepository = new Repository.EspecialidadeRepository();

        }

        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _EspecialidadeRepository.Cadastrar(especialidade);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_EspecialidadeRepository.Listar());
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
                _EspecialidadeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Ërro ao Deletar");
            }
        }
    }
}

