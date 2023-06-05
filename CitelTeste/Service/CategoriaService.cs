using CitelTeste.Model;
using CitelTeste.Repository.Interface;
using CitelTeste.Service.Interface;

namespace CitelTeste.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public CategoriaService(ICategoriaRepositorio categoriaRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            var nomeDuplicado = NomeCategoriaDuplicado(categoria.Nome);

            if(nomeDuplicado)
              throw new Exception("nome já está em uso.");

            _categoriaRepositorio.CadastrarCategoria(categoria);
        }

        public List<Categoria> ListaCategoriaCadastro()
        {
            var listaCategoria = _categoriaRepositorio.ListaCategoria();

            return listaCategoria;  
        }

        public void EditarCategoria(Categoria categoria)
        {
            _categoriaRepositorio.EditarCategoria(categoria);
        }

        public void ApagarCategoria(int id)
        {
            var categoria = ApagarCategoriaVinculada(id);

            if(categoria)
               throw new Exception("categoria em uso. realize a alteração antes de apagar.");

            _categoriaRepositorio.ApagarCategoria(id);
        }

        public bool NomeCategoriaDuplicado(string categoria)
        {
            var listaCategoria = _categoriaRepositorio.ListaCategoria();

            var nomeDuplicado = listaCategoria.Any(x => x.Nome == categoria);

            return nomeDuplicado;
        }

        public bool ApagarCategoriaVinculada(int id)
        {
            var listaCategoria = _produtoRepositorio.ListaProduto();

            var categoriaVinculada = listaCategoria.Any(x => x.Categoria.Id == id);

            return categoriaVinculada;
        }
    }
}
