using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        // GET: api/<ValuesController1>
        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            return await _employeeService.GetAll();
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(Guid id)
        {
            return await _employeeService.GetEmployee(id);
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public async Task Post([FromQuery] EmployeeDTO employee)
        {
            await _employeeService.AddEmployee(employee);
        }

        [HttpPut]
        public async Task Put([FromQuery] PaycheckAssessment assessment)
        {
            await _employeeService.AssessPayment(assessment);
        }
    }
}
