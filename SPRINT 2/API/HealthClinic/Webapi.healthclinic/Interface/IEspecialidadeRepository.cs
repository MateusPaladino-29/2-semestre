using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);
        void Deletar(Guid Id);
        List<Especialidade> Listar();
       
    }
}
