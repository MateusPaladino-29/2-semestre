using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface InstituicaoRepository
    {
        void Cadastrar(Instituicao instituicaoRepository);
        void Deletar(Guid Id);
        List<Instituicao> Listar();
        Instituicao BuscarPorId(Guid Id);
        void Atualizar(Guid Id, Instituicao instituicaoRepository);
    }
}
