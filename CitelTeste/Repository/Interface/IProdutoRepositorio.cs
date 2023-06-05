using CitelTeste.DTO;
using CitelTeste.Model;

namespace CitelTeste.Repository.Interface
{
    public interface IProdutoRepositorio
    {
        void CadastrarProduto(Produto produto);
        List<Produto> ListaProduto();
        void EditarProduto(Produto editarProduto);
        void ApagarProduto(int id);
    }
}