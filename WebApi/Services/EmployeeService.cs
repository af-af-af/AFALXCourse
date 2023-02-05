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
            var paycheck = GeneratePaycheck(employeeDto.LastName, employeeDto.DepartmentName);
            await _paycheckRepository.Create(paycheck);
            var department = await GetDepartment(employeeDto.DepartmentName);
            var employee = CreateEmployee(employeeDto, paycheck.Id, department.Id);
            await _employeeRepository.Create(employee);
        }

        public async Task<Employee> GetEmployee(Guid Id)
        {
            return await _employeeRepository.GetById(Id);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task AssessPayment(PaycheckAssessment assessment)
        {
            var paycheck = await _paycheckRepository.GetByNumber(assessment.PaycheckNumber);
            paycheck.PaymentGross = assessment.PaymentGross;
            paycheck.PaymentNet = paycheck.PaymentGross - _taxService.CalculateTaxDecimal(paycheck.PaymentGross);
            _paycheckRepository.UpdateSalary(paycheck);
        }

        private Paycheck GeneratePaycheck(string lastName, string departmentName)
        {
            var random = new Random();
            var paycheck = new Paycheck
            {
                Id = Guid.NewGuid(),
                PaycheckNumber = $"{lastName}/{departmentName}/" + random.Next(1, 100).ToString()
            };
            return paycheck;
        }

        private async Task<Department> GetDepartment(string departmentName)
        {
            var department = await _departmentRepository.GetByName(departmentName);
            return department;
        }

        private Employee CreateEmployee(EmployeeDTO employeeDto, Guid paycheckId, Guid departmentId)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                DepartmentId = departmentId,
                PaycheckId = paycheckId
            };
            return employee;
        }
    }
}
