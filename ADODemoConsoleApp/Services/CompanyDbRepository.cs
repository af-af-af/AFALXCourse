using ADODemoConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemoConsoleApp.Services
{
    public class CompanyDbRepository
    {
        private string _connectionString;

        public CompanyDbRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void InsertEmployeeToDb(Employee employee)
        {
            var queryString = "insert into employees(id, first_name, last_name, email, department_id) " +
                "values(@id, @firstName, @lastName, @email, @departmentId)";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", employee.Id.ToString());
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@email", employee.Email);
                command.Parameters.AddWithValue("@departmentId", employee.DepartmentId.ToString());

                try 
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception ex) 
                {
                    Console.Write(ex.Message);
                    Console.Write(ex.StackTrace);
                }
                
            }
        }
    }
}
