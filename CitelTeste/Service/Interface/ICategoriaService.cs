using CitelTeste.Model;

namespace CitelTeste.Service.Interface
{
    public interface ICategoriaService
    {
        void CadastrarCategoria(Categoria categoria);
        List<Categoria> ListaCategoriaCadastro();
        void EditarCategoria(Categoria categoria);
        void ApagarCategoria(int id);
    }
}