using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Data;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;

namespace SalesDatePredictionAPI.Repositories
{
    public class EmployeeRepositoy: IEmployeesRepository
    {
        private readonly StoreSampleDbContext _context;
        public EmployeeRepositoy(StoreSampleDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeDto
                {
                    EmpId = e.empid,
                    FullName = e.firstname + " " + e.lastname
                })
                .ToListAsync();
        }

    }
}
