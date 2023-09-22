using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repository
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid Id, Instituicao instituicaoRepository)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(Id)!;

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.NomeFantasia = instituicaoRepository.NomeFantasia;
                instituicaoBuscada.Endereco = instituicaoRepository.Endereco;
                
            }
        }

        public Instituicao BuscarPorId(Guid Id)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(Id)!;

            if (instituicaoBuscada != null)
            {
               return ctx.Instituicao.FirstOrDefault(b => b.IdInstituicao == Id)!;
            }

            return null;


        }

        public void Cadastrar(Instituicao instituicaoRepository)
        {
            try
            {
                ctx.Instituicao.Add(instituicaoRepository);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar a rota de cadastrar");
            }
        }

        public void Deletar(Guid Id)
        {
           Instituicao instituicaoBuscada = ctx.Instituicao.Find(Id);

            if (instituicaoBuscada != null)
            {
                ctx.Instituicao.Remove(instituicaoBuscada);
            }

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
