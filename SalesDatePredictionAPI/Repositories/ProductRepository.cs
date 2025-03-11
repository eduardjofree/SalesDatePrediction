using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Data;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;

namespace SalesDatePredictionAPI.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly StoreSampleDbContext _context;

        public ProductRepository(StoreSampleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetProductAsync()
        {

            return await _context.Products
               .Select(e => new ProductDto
               {
                   Productid = e.productid,
                   Productname = e.productname
               })
               .ToListAsync();
        }
    }
}
