using Microsoft.EntityFrameworkCore;
using StreetParking.API.DbContexts;
using StreetParking.API.Entities;

namespace StreetParking.API.Services
{
    public class StreetParkingService: IStreetParkingService
    {
        private readonly StreetParkingContext _context;

        public StreetParkingService(StreetParkingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }
    }
}
