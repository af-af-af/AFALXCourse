using System.Data.SqlClient;

namespace ADODemoConsoleApp
{
    public class ADODemo
    {
        private string _connectionString;

        public ADODemo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RunSelectAll()
        {
            var queryString = "select * from employees";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]}, {sqlDataReader[1]}, {sqlDataReader[2]}, {sqlDataReader[3]}, {sqlDataReader[4]}");
                    }
                    sqlDataReader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                connection.Close();
            }
        }

        public void RunSelectDefinedColumnSet(string param1, string param2)
        {
            var queryString = $"select {param1}, {param2} from employees";

            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                var command = new SqlCommand(queryString, connection);

                try 
                {
                    connection.Open();
                    var sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]}, {sqlDataReader[1]}");
                    }
                    sqlDataReader.Close();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                connection.Close();
            }
        }
    }
}
