using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;
using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetProductAsync()
        {
            var result = await _productRepository.GetProductAsync();
            return result;
        }
    }
}
