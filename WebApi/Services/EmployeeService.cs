using CommonFunctionalities.Services.Interfaces;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ITaxService _taxService;

        public EmployeeService(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public async Task AddEmployee(EmployeeDTO employeeDto)
        {
            var employee1 = new EmployeeDTO
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                DepartmentName = employeeDto.DepartmentName
            };
        }
    }
}
