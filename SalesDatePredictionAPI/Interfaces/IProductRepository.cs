using SalesDatePredictionAPI.DTOs;

namespace SalesDatePredictionAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductAsync();
    }
}
