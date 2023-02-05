using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
