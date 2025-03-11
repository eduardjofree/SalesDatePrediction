using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByCustomerAsync(int customerId);
        Task<List<ResponsePredictOrderForDateDto>> GetCustomersWithOrderPredictionAsync();
        Task<Order> CreateOrderAsync(Order order, OrderDetail orderDetail);
        Task<List<ResponsePredictOrderForDateDto>> GetByCustomersWithOrderPredictionAsync(string search);

    }
}

