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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository {get; set;}

        public  JogoController() 
        {
            _jogoRepository = new JogoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> jogo = _jogoRepository.ListarTodos();

                return Ok(jogo);    

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                
            }
        
        }


        [HttpPost]
        public IActionResult Post(JogoDomain jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        
        }
    }
}
