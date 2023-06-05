using MySql.Data.MySqlClient;

namespace CitelTeste.Data
{
    public class ConexaoDB
    {
        public MySqlConnection PegarConexao()
        {
            const string db = "Server=127.0.0.1;Database=dbcitel;Uid=root;Pwd=123;";

            MySqlConnection sqlConnection = new(db);
            sqlConnection.Open();

            return sqlConnection;
        }

        public void FecharConexao()
        {
            MySqlConnection sqlConnection = new();

            sqlConnection.Close();
        }
    }
}
