using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
