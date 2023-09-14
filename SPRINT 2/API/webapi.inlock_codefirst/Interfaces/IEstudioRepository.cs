using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscaPorId(Guid id);

        void Cadastrar(EstudioDomain estudio);

        void Atualizar(Guid id, EstudioDomain estudio);

        void Deletar(Guid id);

    }
}
