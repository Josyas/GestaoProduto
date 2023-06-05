using CitelTeste.Data;
using CitelTeste.Model;
using CitelTeste.Repository.Interface;
using Dapper;
using System.Data;

namespace CitelTeste.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ConexaoDB _conexaoDB;

        public ProdutoRepositorio(ConexaoDB conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public void CadastrarProduto(Produto produtoCadastro)
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "INSERT INTO Produto (Nome, Codigo, DataFabricacao, DataVencimento, Valor, IdCategoria) " +
                  "VALUES (@Nome, @Codigo, @DataFabricacao, @DataVencimento, @Valor, @IdCategoria)";

                connection.Execute(query, produtoCadastro);

                _conexaoDB.FecharConexao();
            }
        }

        public List<Produto> ListaProduto()
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "SELECT prod.Id, prod.Nome, prod.Codigo, prod.DataFabricacao, prod.DataVencimento, prod.Valor, cat.Id, cat.Nome " +
                   "FROM Produto prod INNER JOIN Categoria cat ON prod.idCategoria = cat.Id";

                var listaProduto = connection.Query<Produto, Categoria, Produto>(query, (produto, categoria) =>
                {
                    produto.Categoria = categoria;
                    return produto;
                }, splitOn: "Id").ToList();

                _conexaoDB.FecharConexao();

                return listaProduto;
            }
        }

        public void EditarProduto(Produto editarProduto)
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "UPDATE Produto SET Nome = @Nome, Codigo = @Codigo, " +
                "DataFabricacao = @DataFabricacao, DataVencimento = @DataVencimento, Valor = @Valor, IdCategoria = @IdCategoria WHERE Id = @Id";

                connection.Execute(query, editarProduto);

                _conexaoDB.FecharConexao();
            }
        }

        public void ApagarProduto(int id)
        {
            using (IDbConnection connection = _conexaoDB.PegarConexao())
            {
                string query = "DELETE FROM Produto WHERE Id = @Id";

                connection.Execute(query, new { Id = id});

                _conexaoDB.FecharConexao();
            }
        }
    }
}
