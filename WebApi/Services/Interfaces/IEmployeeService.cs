using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployee(EmployeeDTO employeeDto);
    }
}
