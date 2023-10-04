using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;
using Webapi.healthclinic.Repository;

namespace webapi.health.clinic.project.Controllers
{
   /* [Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentario _comentarioConsultaRepository;
        public ComentarioController()
        {
            this._comentarioConsultaRepository = new ComentarioRepository();
        }

        /// <summary>
        /// Rota para cadastrar um novo comentário para uma consulta
        /// </summary>
        /// <param name="novoComentario">Informações do comentário a ser cadastrado</param>
        /// <returns></returns>
        /// 

        
        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioConsultaRepository.Cadastrar(comentario);

                return Ok("Comentário cadastrado com sucesso");

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota para deletar um comentário cadastrado
        /// </summary>
        /// <param name="id">Id do comentário a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioConsultaRepository.BuscarPorId(id);

                if (comentarioBuscado == null)
                {
                    return NotFound("Não há comentátio cadastrado com o id informado");
                }

                _comentarioConsultaRepository.Deletar(id);

                return Ok("Comentário deletado com sucesso");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
