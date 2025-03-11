using SalesDatePredictionAPI.Interfaces;
using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            var result = await _customerRepository.GetCustomerAsync();
            return result;
        }
    }
}
