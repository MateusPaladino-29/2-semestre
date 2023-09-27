using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        void Deletar(Guid Id);
        List<Medico> Listar();
        Medico BuscarPorId(Guid Id);
        
    }
}
