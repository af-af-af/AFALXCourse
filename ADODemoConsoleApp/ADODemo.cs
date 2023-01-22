using ADODemoConsoleApp.Models;
using ADODemoConsoleApp.Services;
using System.Data.SqlClient;

namespace ADODemoConsoleApp
{
    public class ADODemo
    {
        private string _connectionString;
        private CompanyDbRepository _companyDbRepository;

        public ADODemo(string connectionString)
        {
            _connectionString = connectionString;
            _companyDbRepository = new CompanyDbRepository(connectionString);
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

        public void InsertEmployeeDemo()
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "And2rzej",
                LastName = "Paaaaandrzej",
                Email = "apapa1@gmail.com",
                DepartmentId = Guid.Parse("886EEE76-1508-44A6-A172-C2A5255B9DA6")
            };

            _companyDbRepository.InsertEmployeeToDb(employee);
            RunSelectAll();
        }

        public void InsertManyEmployeesDemo()
        {
            var employeeList = new List<Employee>();
            var random = new Random();

            string[] names = { "Michał", "Andrzej", "Marcin", "Monika" };
            string[] lastNames = { "Kowalski", "Nowak", "Miau", "Hau" };


            for (int i = 0; i < 100; i++)
            {
                employeeList.Add(new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = names[random.NextInt64(0, 4)],
                    LastName = lastNames[random.NextInt64(0, 4)],
                    Email = names[random.NextInt64(0, 3)] + names[random.NextInt64(0, 3)] + names[random.NextInt64(0, 3)] + random.NextInt64().ToString() + "@gmail.com",
                    DepartmentId = Guid.Parse("47DD8E6D-E37D-4EEE-AEA8-3B3D9057F204")
                });
                Console.WriteLine("Employee created...");
            }

            foreach (var employee in employeeList)
            {
                _companyDbRepository.InsertEmployeeToDb(employee);
                Console.WriteLine("Employee inserted...");
            }
        }
    }
}
