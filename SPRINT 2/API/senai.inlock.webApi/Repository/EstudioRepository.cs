using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class EstudioRepository : IEstudioRepository
    {

        private string? stringConexao = "Data Source = NOTE05-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";

        public void Cadastrar(estudioDomain Estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "Insert into Estudio(IdEstudio, Nome) = Values(@IdEstudio, @Nome)";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", Estudio.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", Estudio.Nome);


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }

        public void Cadastrar(EstudioDomain estudio)
        {
            throw new NotImplementedException();
        }

        public List<estudioDomain> ListarTodos()
        {
            List<estudioDomain> ListarEstudio = new List<estudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelct = "select Estudio.IdEstudio, Estudio.Nome, Jogo.Nome from Estudio left join Jogo on Estudio.IdJogo = Jogo.IdJogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelct, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        estudioDomain Estudio = new estudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),


                        };
                        ListarEstudio.Add(Estudio);

                    };


                }
            }

            return ListarEstudio;


        }

        List<EstudioDomain> IEstudioRepository.ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
