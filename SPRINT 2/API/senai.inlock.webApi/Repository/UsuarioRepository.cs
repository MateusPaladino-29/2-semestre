using senai.inlock.webApi.Domain;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class UsuarioRepository
    {

        private string? stringConexao = "Data Source = NOTE05-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";

        public void Cadastrar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "Insert into Jogo(IdEstudio, Nome, Descricao,DataLancamento,Preco) = Values(@IdJogo, @Nome, @Descricao,@DataLancamento,@Preco) ";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@IdJogo", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Preco", jogo.Preco);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }

        public List<JogoDomain> ListarTodos()
        { 
            List<JogoDomain> ListarJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelct = "select IdJogo, Nome, Descricao, DataLancamento, Preco from Jogo inner join Estudio on Jogo.IdEstudio = Estudio.Idtudio";
            }
        
        }

    }
}
