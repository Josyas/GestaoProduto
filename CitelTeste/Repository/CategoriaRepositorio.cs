using CitelTeste.Data;
using CitelTeste.Model;
using CitelTeste.Repository.Interface;
using Dapper;
using System.Data;

namespace CitelTeste.Repository
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ConexaoDB _conexaoDB;

        public CategoriaRepositorio(ConexaoDB conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public void CadastrarCategoria(Categoria categoriaCadastro)
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "INSERT INTO Categoria (Nome) VALUES (@Nome)";

                connection.Execute(query, categoriaCadastro);

                _conexaoDB.FecharConexao();
            }
        }

        public List<Categoria> ListaCategoria()
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "SELECT * FROM Categoria";

                var listaCategoria = connection.Query<Categoria>(query).ToList();

                _conexaoDB.FecharConexao();

                return listaCategoria;
            }
        }

        public void EditarCategoria(Categoria editarCategoria)
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "UPDATE Categoria SET Nome = @Nome  WHERE Id = @Id";

                connection.Execute(query, editarCategoria);

                _conexaoDB.FecharConexao();
            }
        }

        public void ApagarCategoria(int id)
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "DELETE FROM Categoria WHERE Id = @Id";

                connection.Execute(query, new { Id = id });

                _conexaoDB.FecharConexao();
            }
        }
    }
}
