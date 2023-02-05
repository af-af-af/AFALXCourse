using System.Data.SqlClient;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private const string _connectionString = "";

        public async Task Create(Department department)
        {
            var queryString = "insert into Departments(Id, DepartmentName) values(@id, @name)";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", department.Id.ToString());
                command.Parameters.AddWithValue("@name", department.DepartmentName);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<List<Department>> GetAll()
        {
            var departments = new List<Department>();
            var queryString = "select * from Departments";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var department = new Department
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            DepartmentName = sqlDataReader[1].ToString()
                        };
                        departments.Add(department);
                    }
                    sqlDataReader.Close();
                    return departments;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Department> GetById(Guid Id)
        {
            var departments = new List<Department>();
            var queryString = $"select * from Departments where Id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                sqlCommand.Parameters.AddWithValue("@id", Id.ToString());
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var department = new Department
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            DepartmentName = sqlDataReader[1].ToString()
                        };
                        departments.Add(department);
                    }
                    sqlDataReader.Close();
                    return departments.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
            }
        }

        public async Task<Department> GetByName(string departmentName)
        {
            var departments = new List<Department>();
            var queryString = $"select * from Departments where DepartmentName = @departmentName";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                sqlCommand.Parameters.AddWithValue("@departmentName", departmentName);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var department = new Department
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            DepartmentName = sqlDataReader[1].ToString()
                        };
                        departments.Add(department);
                    }
                    sqlDataReader.Close();
                    return departments.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
            }
        }
    }
}