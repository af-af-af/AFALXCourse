using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployee(EmployeeDTO employeeDto);
        Task<Employee> GetEmployee(Guid Id);
        Task<List<Employee>> GetAll();
        Task AssessPayment(PaycheckAssessment assessment);
    }
}
