using System.CodeDom.Compiler;
using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Responsavel pelo repositorio generorepository
    /// define os metodos que tera no repositorio
    /// </summary>
    public interface IGeneroRepository
    { //CRUD

        //TipoDeRetorno NomeMetodo(TipoParametro NomeParametro)


        /// <summary>
        /// Responsavel por cadastrar um novo genero
        /// </summary>
        /// <param name="NovoGenero">Objeto que sera cadastrado</param>
        void Cadastrar(GeneroDomain NovoGenero);

        /// <summary>
        /// Retornar todos os generos cadastrados
        /// </summary>
        /// <returns> Uma lista de Objeto </returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// buscar um objeto pelo seu id 
        /// </summary>
        /// <param name="id">id od objeto que sera buscado </param>
        /// <returns>objeto que foi buscado</returns>       
        GeneroDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza um genero existente passando o Id pelo corpo da requisição
        /// </summary>
        /// <param name="Genero">Objeto genero com as novas informações</param>

        void AtualizarIdCorpo(GeneroDomain Genero);

        /// <summary>
        ///  Atualiza um genero existente passando o Id pela url da requisição
        /// </summary>
        /// <param name="Id">id do objeto a ser atualizado</param>
        /// <param name="Genero">Objeto com as novas informações</param>

        void AtualizarIdUrl(int Id, GeneroDomain Genero);

        /// <summary>
        /// Deleta o genero existente pelo id
        /// </summary>
        /// <param name="Id">Id do objeto a ser deletado</param>
        void Deletar(int Id);





    }
}
