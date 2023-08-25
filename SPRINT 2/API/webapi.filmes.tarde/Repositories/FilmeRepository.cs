using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        /// <summary>
        /// STRING DE CONEXAO COM O BANCO DE DADOS QUE RECEBEM OS SEGUINTES PARÂMETROS
        /// DATA SOURCE = nome do servidor;
        /// INITIAL CATALOG = Nome do banco de dados;
        /// AUTENTIFICAÇÃO:
        ///     - WINDOWS =  Integrated Secutiry = True;
        ///     - SQLSERVER = User Id = sa; Senha = Senha;
        /// </summary>
        /// 
       
        public void AtualizarIdCorpo(FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdURL(int Id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
