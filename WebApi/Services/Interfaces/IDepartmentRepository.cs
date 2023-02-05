using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department> 
    {
        Task<Department> GetByName(string departmentName);
    }
}
