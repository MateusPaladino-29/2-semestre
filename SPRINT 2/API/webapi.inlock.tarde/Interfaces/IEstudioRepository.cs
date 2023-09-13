using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();
        Estudio BuscarPorId(Estudio estudio);
        void Cadastrar (Estudio estudio);
        void Atualizar (Estudio estudio);
        void Deletar (Estudio estudio);
        List<Estudio> ListarComJogos(); 


    }
}
