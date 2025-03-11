using SalesDatePredictionAPI.DTOs;

namespace SalesDatePredictionAPI.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<List<EmployeeDto>> GetEmployeesAsync();
    }
}
