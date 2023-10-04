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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository;

        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();

        }

        [Authorize("Administrador")]
        [HttpPost]
        
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _ClinicaRepository.Cadastrar(clinica);

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
                return Ok(_ClinicaRepository.Listar());
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
                _ClinicaRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        
        [HttpGet("BuscaPorID/{id}")]
        public IActionResult GetbyId(Guid id)
        {
            try
            {
                return Ok(_ClinicaRepository.BuscarPorId(id));


            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }

        }

        /*[HttpGet("BuscaPorID/{id}")]
        public IActionResult GetbyId(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = _ClinicaRepository.BuscarPorId(id);
                if (clinicaBuscada == null)
                {
                    return NotFound("Clinica buscada não encontrada");
                }

                return Ok(clinicaBuscada);  


            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }

        }*/

        [Authorize("Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                _ClinicaRepository.Atualizar(id, clinica);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Buscar");
            }


        }
    }
}
