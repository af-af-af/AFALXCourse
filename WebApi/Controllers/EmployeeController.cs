using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<ValuesController1>
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return new List<Employee>() { new Employee 
            {
                Id = Guid.NewGuid(),
                FirstName= "Test",
                LastName= "TestLastName",
                DepartmentId= Guid.NewGuid(),
                PaycheckId= Guid.NewGuid(),
                Email = "test@paparam.com"
            } };
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "TestLastName",
                DepartmentId = Guid.NewGuid(),
                PaycheckId = Guid.NewGuid(),
                Email = "test@paparam.com"
            };
         }

        // POST api/<ValuesController1>
        [HttpPost]
        public async Task Post([FromQuery] EmployeeDTO employee)
        {
            var employee1 = new EmployeeDTO
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DepartmentName = employee.DepartmentName
            };
        }
    }
}
