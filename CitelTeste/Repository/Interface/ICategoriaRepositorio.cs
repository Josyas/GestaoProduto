using CitelTeste.Model;

namespace CitelTeste.Repository.Interface
{
    public interface ICategoriaRepositorio
    {
        void CadastrarCategoria(Categoria categoriaCadastro);
        List<Categoria> ListaCategoria();
        void EditarCategoria(Categoria editarCategoria);
        void ApagarCategoria(int id);
    }
}