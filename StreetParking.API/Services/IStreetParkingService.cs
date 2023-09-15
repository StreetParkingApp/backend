using StreetParking.API.Entities;

namespace StreetParking.API.Services
{
    public interface IStreetParkingService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}
