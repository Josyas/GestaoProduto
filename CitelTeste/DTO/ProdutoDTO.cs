namespace CitelTeste.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public float Valor { get; set; }
        public int IdCategoria { get; set; }
    }
}
