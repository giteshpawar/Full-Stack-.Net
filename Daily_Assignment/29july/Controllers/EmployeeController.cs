
using _29july.Models;
using _29july.Services;
using Microsoft.AspNetCore.Mvc;

namespace _29july.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            var employees = _employeeService.getEmployees();
            return Ok(employees);
        }

        // GET: api/Employees/dept/11
        [HttpGet("dept/{deptId}")]
        public ActionResult<Employee> GetEmployeeByDeptId(int deptId)
        {
            var employee = _employeeService.getEmployee(deptId);
            if (employee == null)
            {
                return NotFound($"No employee found for DeptId: {deptId}");
            }
            return Ok(employee);
        }

        // GET: api/Employees/name/Mamta
        [HttpGet("name/{name}")]
        public ActionResult<Employee> GetEmployeeByName(string name)
        {
            var employee = _employeeService.getEmployeeName(name);
            if (employee == null)
            {
                return NotFound($"No employee found with Name: {name}");
            }
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEmployee = _employeeService.addEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeByName), new { name = createdEmployee.Name }, createdEmployee);
        }
    }
}