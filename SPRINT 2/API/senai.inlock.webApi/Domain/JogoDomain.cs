namespace senai.inlock.webApi.Domain
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public string? Nome { get; set; }
        public string? Descricao  { get; set; }
        public DateTime DataLancamento { get; set; }
        public float Preco { get; set; }
    }
}
