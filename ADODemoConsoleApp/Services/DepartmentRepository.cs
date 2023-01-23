using ADODemoConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemoConsoleApp.Services
{
    public class DepartmentRepository
    {
        private string _connectionString;

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertDepartmentToDB(Department department)
        {
            var queryString = "insert into departments(id, department_name) values(@id, @name)";

            using (var connection = new SqlConnection(_connectionString)) 
            { 
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", department.Id.ToString());
                command.Parameters.AddWithValue("@name", department.DepartmentName);
                try 
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                } 
                finally 
                { 
                    connection.Close(); 
                }
            }
        }

        public List<Department> GetAll() 
        {
            var departments = new List<Department>();
            var queryString = "select * from departments";

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
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
                finally 
                {
                    connection.Close();
                }
            }
        }

        public Department GetById(Guid id)
        {
            var departments = new List<Department>();
            var queryString = $"select * from departments where id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                sqlCommand.Parameters.AddWithValue("@id", id.ToString());
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
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
