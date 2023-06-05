namespace CitelTeste.Model
{
    public class Produto : EntidadeBase
    {
        public string Codigo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public float Valor { get; set; }
        public int idCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
