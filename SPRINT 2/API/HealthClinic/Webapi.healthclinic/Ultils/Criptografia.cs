namespace Webapi.healthclinic.Ultils
{
    public class Criptografia
    {
        /// <summary>
        /// Gerar uma hash apartir de uma senha 
        /// </summary>
        /// <param name="senha">Senha que recebera a hash </param>
        /// <returns>A senha criptografada com a hash</returns>
        public static string GerarHash(String senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);

        }

        /// <summary>
        /// Verifica se a hash da senha informada é igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuario</param>
        /// <param name="senhaBanco">Senha cadastrada no Banco</param>
        /// <returns>True ou false (Senha é verdadeira?)</returns>
        public static bool CompararHash(String senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
