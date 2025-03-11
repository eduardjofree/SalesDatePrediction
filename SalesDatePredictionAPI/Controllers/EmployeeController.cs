using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Models;
using SalesDatePredictionAPI.Services;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            if (employees == null)
            {
                return NotFound("No found employees.");
            }
            return Ok(employees);
        }
    }
}
