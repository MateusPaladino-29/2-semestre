using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string? stringConexao = "Data Source = NOTE05-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";


        public UsuarioDomain Login(String Email, String Senha)
        {
            UsuarioDomain Usuario = null;

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelect = "select IdUsuario,IdTipoUsuario, Email, Senha from Usuario where Email = @Email and Senha = @Senha ";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con ))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);


                    con.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            Usuario = new UsuarioDomain
                            {
                              IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                              IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                              Email = rdr["Email"].ToString(),
                              Senha = rdr["Senha"].ToString(),
                             

                            };
                        }
                    }
                }


            }

            return Usuario;

        }

        
    }
}
