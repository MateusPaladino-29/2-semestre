using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(FilmeDomain Filme);

        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int Id);


        void AtualizarIdCorpo(FilmeDomain Filme);

        void AtualizarIdURL(int Id, FilmeDomain filme);

        void Deletar(int id);
            
    }
}
