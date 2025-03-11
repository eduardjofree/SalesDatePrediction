using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Data;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;

namespace SalesDatePredictionAPI.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreSampleDbContext _context;

        public ShipperRepository(StoreSampleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShipperDto>> GetShipperAsync()
        {

            return await _context.Shippers
               .Select(e => new ShipperDto
               {
                   Shipperid = e.shipperid,
                   Companyname = e.companyname,
               })
               .ToListAsync();
        }
    }
}
