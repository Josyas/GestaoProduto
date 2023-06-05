using CitelTeste.Model;
using CitelTeste.Repository.Interface;
using CitelTeste.Service.Interface;

namespace CitelTeste.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public void CadastrarProduto(Produto produto)
        {
            var nomeDuplicado = NomeProdutoDuplicado(produto.Nome);

            if(nomeDuplicado)
               throw new Exception("nome já está em uso.");

            _produtoRepositorio.CadastrarProduto(produto);
        }

        public List<Produto> ListaProdutroCadastrado()
        {
            var listaProduto = _produtoRepositorio.ListaProduto();

            return listaProduto;
        }

        public void EditarProduto(Produto produto)
        {
            _produtoRepositorio.EditarProduto(produto);
        }

        public void ApagarProduto(int id)
        {
            _produtoRepositorio.ApagarProduto(id);
        }

        public bool NomeProdutoDuplicado( string nome)
        {
            var listaProduto = _produtoRepositorio.ListaProduto();

            var nomeDuplicado = listaProduto.Any(x => x.Nome == nome);

            return nomeDuplicado;
        }
    }
}
