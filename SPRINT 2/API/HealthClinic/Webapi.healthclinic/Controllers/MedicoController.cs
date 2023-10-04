using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicoController()
        {
            _MedicoRepository = new Repository.MedicoRepository();

        }

        /* [Authorize("Administrador")]*/
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _MedicoRepository.Cadastrar(medico);
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
                return Ok(_MedicoRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Error ao Listar");
            }
        }

        [Authorize("Administrador")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _MedicoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Ërro ao Deletar");
            }
        }

        /* [Authorize("Administrador")]*/
        [HttpGet("{Id}")]
        public IActionResult GetbyId(Guid id)
        {
            try
            {
                return Ok(_MedicoRepository.BuscarPorId(id));


            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }

        
    }
}

