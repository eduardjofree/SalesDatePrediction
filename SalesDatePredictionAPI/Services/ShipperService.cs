using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;

namespace SalesDatePredictionAPI.Services
{
    public class ShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<List<ShipperDto>> GetShipperAsync()
        {
            var result = await _shipperRepository.GetShipperAsync();
            return result;
        }
    }
}
