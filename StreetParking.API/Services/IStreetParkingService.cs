using StreetParking.API.Entities;

namespace StreetParking.API.Services
{
    public interface IStreetParkingService
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<City?> GetCityById(int cityId);

        Task<bool> CityExistByNameAsync(string name);

        Task<bool> SaveChangesAsync();

        Task AddCityAsync(City city);
    }
}
