using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Repository;

namespace Webapi.healthclinic.Interface
{
    public interface IComentario
    {
        void Cadastrar(Comentario comentario);
        void Deletar(Guid id);
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
    }
}
