using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers   
{
    /// <summary>
    /// Define que a rota de umna requisicao sera do seguinto formato dominnio/API/controller 
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    ///dedine que é umc controlador de api
    [ApiController]

    /// define que o tipo de resposta da api é json
    [Produces("application/json")]
    

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que ira receber os metodos definidos na interface 
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instancia do objeto _GeneroRespository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o metodo de listar de uma lista de genero
        /// </summary>
        /// <returns>lista de genero do statuscode</returns>

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            try
            {
                //cria lista para receber os generos
                List<GeneroDomain> generos = _GeneroRepository.ListarTodos();
                //retorna o statuscode Ok e a listagem de generos do formato json
                return Ok(generos);
            }

            catch (Exception erro)
            {
                //retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
                throw;
            }



        }


        /// <summary>
        /// Endpoint que acessa o metodo de cadastrar genero
        /// </summary>
        /// <param name="novoGenero">objeto recebido na requesisção</param>
        /// <returns>statusCode</returns>
        /// 
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult post(GeneroDomain NovoGenero)
        {

            try
            {
                //faz chamada para o metodo cadastrar
                _GeneroRepository.Cadastrar(NovoGenero);

                //retorna um statusCode
                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);

            }


        }


        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _GeneroRepository.Deletar(Id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }


        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(int Id)
        {
            try
            {
                GeneroDomain generoDomain = _GeneroRepository.BuscarPorId(Id);

                if (generoDomain == null)
                {
                    return NotFound("O genero buscado nao foi encontrado");
                }

                return Ok(generoDomain);


            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int Id, GeneroDomain genero)
        {
            try
            {
                _GeneroRepository.AtualizarIdUrl(Id, genero);

                return StatusCode(201);
            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }




        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult PutId( GeneroDomain Genero)
        {
            try
            {
               GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(Genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _GeneroRepository.AtualizarIdCorpo(Genero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }

                    
                }
                return NotFound("Genero nao encontrado");

            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }







    }
}




//Get para procurar o Id*****************





//salvar e rodar. usou o postman 
//cadastra uma nova rota no + 
//inves de get colocar post 
//