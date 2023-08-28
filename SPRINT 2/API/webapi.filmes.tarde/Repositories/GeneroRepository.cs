using System.Data.SqlClient;
using System.IO.Enumeration;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
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

        public void AtualizarIdCorpo(GeneroDomain Genero, int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))

            {
                string QueryUpdateCorpo = "UPDATE  Genero SET Nome = @NomeInserir where IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(QueryUpdateCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@NomeInserir", Genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int Id, GeneroDomain genero)
        {
            using (SqlConnection con =  new SqlConnection(stringConexao))
            {
                string QueryUpdateUrl = "UPDATE  Genero SET Nome = @NomeInserir where IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(QueryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@NomeInserir", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", Id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int Id)
        {
            GeneroDomain generoEncontrado = new GeneroDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectGenero = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = " +Id;

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectGenero, con))
                {

                    rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            generoEncontrado = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            };
                        }
                    
                }
            }

            return generoEncontrado;
        }



        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryDelete = $"Delete from genero where IdGenero = {Id}";

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                   

                    con.Open();

                    cmd.ExecuteNonQuery();
                }


            }
        }

        /// <summary>
        /// Listar todos os objetos do tipo genero 
        /// </summary>
        /// <returns>Lista de objetos do tipo genero</returns>

        public List<GeneroDomain> ListarTodos()
        {
            //Criar uma lista de genero onde sera armazenados os generos 
            List<GeneroDomain> ListaGenero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a instruicao a ser criada 
                string QuerySelectGenero = "select IdGenero,Nome from Genero";

                //abre a conexao com o banco dados
                con.Open();

                //Declara o sql data reader para percecorrer a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o dqlcommand passando a query que sera executada e a conexao

                using (SqlCommand cmd = new SqlCommand(QuerySelectGenero, con))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();
                    //Enquantohouver registros para serem lidos o laço se repetira 
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor da primeira coluna da tabela 
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade Nome em valor da Coluna Nome 
                            Nome = rdr["Nome"].ToString(),
                        };

                        //adiciona o objeto criado dentro da lista e tem que estar dentro do laço
                        ListaGenero.Add(genero);
                    };


                }

            }

            //Retorna a lista de genero
            return ListaGenero;
        }





        /// <summary>
        /// cadastrar um novo genero
        /// </summary>
        /// <param name="NovoGenero">novoGenero</param>

        public void Cadastrar(GeneroDomain NovoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declaramos a query que sera executada 
                string queryInsert = "insert into Genero(Nome) values(@Nome) ";

                //declara o sqlcommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", NovoGenero.Nome);

                    //abre conexao com o banco de dados 
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }


        }

    }

}
