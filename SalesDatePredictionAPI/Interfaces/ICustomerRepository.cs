using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomerAsync();
    }
}
