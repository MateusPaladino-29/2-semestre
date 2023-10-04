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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _PacienteRepository { get; set; }

        public PacienteController()
        {
            _PacienteRepository = new Repository.PacienteRepository();

        }

        /* [Authorize("Administrador")]*/
        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _PacienteRepository.Cadastrar(paciente);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar");
            }
        }

        /*[Authorize("Paciente")]*/
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_PacienteRepository.Listar());
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
                _PacienteRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Ërro ao Deletar");
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetbyId(Guid id)
        {
            try
            {
                return Ok(_PacienteRepository.BuscarPorId(id));


            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }

        /* [Authorize("Administrador")]*/
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _PacienteRepository.Atualizar(id, paciente);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }
    }

}
