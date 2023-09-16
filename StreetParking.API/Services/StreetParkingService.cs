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

        public async Task<City?> GetCityById(int cityId)
        {
            return await _context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<bool> CityExistByNameAsync(string name)
        {
            return await _context.Cities.AnyAsync(c => c.Name == name);
        }

        public async Task AddCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
