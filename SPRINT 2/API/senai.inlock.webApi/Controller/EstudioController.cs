using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    [Produces("application/json")]
    public class estudioController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }

        public estudioController()
        {
            _EstudioRepository = new EstudioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> Estudio = _EstudioRepository.ListarTodos();

                return Ok(Estudio);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }


        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(estudioDomain estudio)
        {
            try
            {
                _EstudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
    }
}
