using CommonFunctionalities.Services.Interfaces;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ITaxService _taxService;
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;
        private IPaycheckRepository _paycheckRepository;

        public EmployeeService(ITaxService taxService,
                               IEmployeeRepository employeeRepository,
                               IDepartmentRepository departmentRepository,
                               IPaycheckRepository paycheckRepository)
        {
            _taxService = taxService;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _paycheckRepository = paycheckRepository;
        }

        public async Task AddEmployee(EmployeeDTO employeeDto)
        {

        }
    }
}
