using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        /// <summary>
        /// STRING DE CONEXAO COM O BANCO DE DADOS QUE RECEBEM OS SEGUINTES PARÂMETROS
        /// DATA SOURCE = nome do servidor;
        /// INITIAL CATALOG = Nome do banco de dados;
        /// AUTENTIFICAÇÃO:
        ///     - WINDOWS =  Integrated Secutiry = True;
        ///     - SQLSERVER = User Id = sa; Senha = Senha;
        /// </summary>
        /// 

        private string? stringConexao = "Data Source = NOTE05-S14; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";



        public void AtualizarIdCorpo(FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpId = "Update Filme set Titulo = @NovoTitulo, IdGenero = @NovoGenero where IdFilme = @IdFilme ";

                using (SqlCommand cmd = new SqlCommand(QueryUpId,con))
                {
                    cmd.Parameters.AddWithValue("@NovoTitulo", Filme.Titulo);
                    cmd.Parameters.AddWithValue("@NovoGenero", Filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", Filme.IdFilme);

                    con.Open(); 

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdURL(int Id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpUrl = "Update Filme set Titulo = @NovoTitulo, IdGenero = @NovoGenero where IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(QueryUpUrl, con))
                {
                    cmd.Parameters.AddWithValue("@NovoTItulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@NovoGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme",Id );


                    con.Open(); 

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int Id)
        {
            FilmeDomain filmeEncontrado = new FilmeDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectFilme = "SELECT IdFilme,IdGenero, Titulo FROM Filme WHERE IdFilme = " + Id;

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectFilme, con))
                {

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        filmeEncontrado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                    }

                }
            }

            return filmeEncontrado;
        }

        public void Cadastrar(FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declaramos a query que sera executada 
                string queryInsert = "insert into Filme(IdGenero,Titulo) values(@IdGenero, @Titulo)";

                //declara o sqlcommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", Filme.IdGenero );
                    cmd.Parameters.AddWithValue("@Titulo", Filme.Titulo);

                    //abre conexao com o banco de dados 
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int Id)
        {
             using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryDelete = $"Delete from Filme where IdFilme = {Id}";

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                   

                    con.Open();

                    cmd.ExecuteNonQuery();
                }


            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a instruicao a ser criada 
                string QuerySelectFilme = "select IdGenero,IdFilme, Titulo from Filme";

                //abre a conexao com o banco dados
                con.Open();

                //Declara o sql data reader para percecorrer a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o dqlcommand passando a query que sera executada e a conexao

                using (SqlCommand cmd = new SqlCommand(QuerySelectFilme, con))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();
                    //Enquantohouver registros para serem lidos o laço se repetira 
                    while (rdr.Read())
                    {
                        FilmeDomain Filme = new FilmeDomain()
                        {
                            //atribui a propriedade IdGenero o valor da primeira coluna da tabela 
                            IdFilme = Convert.ToInt32(rdr[1]),

                            IdGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade Nome em valor da Coluna Nome 
                            Titulo = rdr["Titulo"].ToString()
                        };

                        //adiciona o objeto criado dentro da lista e tem que estar dentro do laço
                        ListaFilme.Add(Filme);
                    };


                }

            }

            //Retorna a lista de Filme
            return ListaFilme;
        }

        
    }
}
