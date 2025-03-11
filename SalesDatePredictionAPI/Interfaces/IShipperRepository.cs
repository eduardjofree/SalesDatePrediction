using SalesDatePredictionAPI.DTOs;

namespace SalesDatePredictionAPI.Interfaces
{
    public interface IShipperRepository
    {
        Task<List<ShipperDto>> GetShipperAsync();
    }
}
