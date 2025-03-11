using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Data;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;
using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly StoreSampleDbContext _context;
        public CustomerRepository(StoreSampleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
