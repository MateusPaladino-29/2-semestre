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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _InstituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _InstituicaoRepository = new InstituicaoRepository();

        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _InstituicaoRepository.Cadastrar(instituicao);

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
                return Ok(_InstituicaoRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar");
            }

        }

        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _InstituicaoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                _InstituicaoRepository.Atualizar(id, instituicao);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Atualizar");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar");
            }
        }
      
    }
}
