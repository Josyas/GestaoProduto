namespace CitelTeste.DTO
{
    public class ProdutoListacadastradoDTO
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public float Preco { get; set; }
        public string Categoria { get; set; }
    }
}
