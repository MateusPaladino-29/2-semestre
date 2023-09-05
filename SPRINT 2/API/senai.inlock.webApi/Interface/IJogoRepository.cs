using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IJogoRepository
    {
        void Cadastrar(JogoDomain Jogo);

        List<JogoDomain> ListarTodos();
    }
}
