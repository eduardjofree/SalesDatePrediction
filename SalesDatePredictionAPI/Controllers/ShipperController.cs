using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Services;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("api/Shipper")]
    public class ShipperController: ControllerBase
    {
        private readonly ShipperService _shipperService;

        public ShipperController(ShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet("GetAllShippers")]
        public async Task<ActionResult<IEnumerable<ShipperDto>>> GetEmployees()
        {
            var shippers = await _shipperService.GetShipperAsync();
            if (shippers == null || shippers.Count == 0)
            {
                return NotFound("No found shippers.");
            }
            return Ok(shippers);
        }
    }
}
