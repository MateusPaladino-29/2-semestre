using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
       
        void Cadastrar(estudioDomain estudio);
        List<EstudioDomain> ListarTodos();
    }
}
