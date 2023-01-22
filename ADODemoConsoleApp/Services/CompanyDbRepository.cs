using ADODemoConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

        }
    }
}
