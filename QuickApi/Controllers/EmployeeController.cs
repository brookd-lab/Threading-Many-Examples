using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickApi.Data;
using QuickApi.Models;
using QuickApi.Services;

namespace QuickApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _service.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _service.GetEmployeeById(id);
            
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            var foundEmployee = await _service.GetEmployeeById(employee.Id);

            if (foundEmployee == null)
            {
                return NotFound($"Employee: {employee.Id}, Not Found");
            }

            await _service.UpdateEmployee(employee);

            return Ok();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var foundEmployee = await _service.GetEmployeeById(id);

            if (foundEmployee == null)
            {
                return NotFound($"Employee: {id}, Not Found");
            }

            await _service.DeleteEmployee(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            await _service.CreateEmployee(employee);
            return Created();
        }
    }
}
