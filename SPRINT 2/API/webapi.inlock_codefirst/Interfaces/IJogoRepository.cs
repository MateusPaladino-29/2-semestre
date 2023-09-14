using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IJogoRepository
    {
        List<jogoDomain> Listar();

        jogoDomain BuscarPorId(Guid id);

        void Cadastrar(jogoDomain novo_jogo);

        void Atualizar(Guid Id, jogoDomain jogo);

        void Deletar(Guid Id);
    }
}
