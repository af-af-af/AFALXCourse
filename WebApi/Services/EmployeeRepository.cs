using System.Data.SqlClient;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string _connectionString = "Data Source=DESKTOP-TTJ6DGH\\SQLEXPRESS;Initial Catalog=WebCompany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public async Task Create(Employee employee)
        {
            var queryString = "insert into Employees(Id, FirstName, LastName, Email, DepartmentId, PaycheckId) " +
                "values(@id, @firstName, @lastName, @email, @departmentId, @paycheckId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", employee.Id.ToString());
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@email", employee.Email);
                command.Parameters.AddWithValue("@departmentId", employee.DepartmentId.ToString());
                command.Parameters.AddWithValue("@paycheckId", employee.PaycheckId.ToString());
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = new List<Employee>();
            var queryString = "select * from Employees";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var employee = new Employee
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            FirstName = sqlDataReader[1].ToString(),
                            LastName = sqlDataReader[2].ToString(),
                            Email = sqlDataReader[3].ToString(),
                            DepartmentId = Guid.Parse(sqlDataReader[4].ToString()),
                            PaycheckId = Guid.Parse(sqlDataReader[5].ToString()),
                        };
                        employees.Add(employee);
                    }
                    sqlDataReader.Close();
                    return employees;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Employee> GetById(Guid Id)
        {
            var queryString = "select * from Employees where Employees.Id=@id";
            var employees = new List<Employee>();

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
                        var employee = new Employee
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            FirstName = sqlDataReader[1].ToString(),
                            LastName = sqlDataReader[2].ToString(),
                            Email = sqlDataReader[3].ToString(),
                            DepartmentId = Guid.Parse(sqlDataReader[4].ToString()),
                            PaycheckId = Guid.Parse(sqlDataReader[5].ToString())
                        };
                        employees.Add(employee);
                    }
                    sqlDataReader.Close();
                    return employees.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
