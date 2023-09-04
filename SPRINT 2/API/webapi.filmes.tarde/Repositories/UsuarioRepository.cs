using System.Data.SqlClient;
using System.IO.Enumeration;
using webapi.filmes.tarde.Domains;

using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string? stringConexao = "Data Source = NOTE05-S14; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";


        public void Login(string email, UsuarioDomain LoginUsuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuario = null;

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT IdUsuario, Permissao, Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();
                     
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            usuario = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = rdr["Email"].ToString(),
                                Senha = rdr["Senha"].ToString(),
                                Permissao = rdr["Permissao"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;

        }
    }
   
}
