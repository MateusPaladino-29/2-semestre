using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        void Deletar(Guid Id);
        List<Paciente> Listar();
        Paciente BuscarPorId(Guid Id);
        void Atualizar(Guid Id, Paciente paciente);
    }
}
