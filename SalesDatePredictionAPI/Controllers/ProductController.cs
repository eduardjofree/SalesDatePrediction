using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Services;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetEmployees()
        {
            var products = await _productService.GetProductAsync();
            if (products == null || products.Count == 0)
            {
                return NotFound("No found products.");
            }
            return Ok(products);
        }
    }
}
