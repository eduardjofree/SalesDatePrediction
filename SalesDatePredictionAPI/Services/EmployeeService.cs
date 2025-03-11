using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;

namespace SalesDatePredictionAPI.Services
{
    public class EmployeeService
    {
        private readonly IEmployeesRepository _employeeRepository;

        public EmployeeService(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
    }
}
