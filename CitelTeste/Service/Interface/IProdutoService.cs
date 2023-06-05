using CitelTeste.Model;

namespace CitelTeste.Service.Interface
{
    public interface IProdutoService
    {
        void CadastrarProduto(Produto produto);
        void EditarProduto(Produto produto);
        void ApagarProduto(int id);
        List<Produto> ListaProdutroCadastrado();
    }
}