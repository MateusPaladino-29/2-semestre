using senai.inlock.webApi.Domain;

using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;



namespace senai.inlock.webApi.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private string? stringConexao = "Data Source = NOTE05-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";

        public void Cadastrar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "Insert into Jogo(IdEstudio, Nome, Descricao,DataLancamento,Preco) = Values(@IdJogo, @Nome, @Descricao,@DataLancamento,@Preco) ";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", jogo.IdJogo);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
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
                string QuerySelct = "select Jogo.IdJogo, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Preco, Estudio.Nome from Jogo inner join Estudio on Jogo.IdEstudio = Estudio.Idtudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelct, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr[1].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[2]),
                            Preco = Convert.ToInt32(rdr[3])

                        };
                        ListarJogo.Add(jogo);

                    };


                }
            }

            return ListarJogo;

        }

    }
}

