using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Models;
using SalesDatePredictionAPI.Services;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var customers = await _customerService.GetCustomerAsync();
            if (customers == null || customers.Count == 0)
            {
                return NotFound("No found customers.");
            }
            return Ok(customers);
        }
    }
}
