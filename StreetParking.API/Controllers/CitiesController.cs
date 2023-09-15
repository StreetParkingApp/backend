using Microsoft.AspNetCore.Mvc;
using StreetParking.API.Models;
using StreetParking.API.Services;

namespace StreetParking.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly IStreetParkingService _streetParkingService;

        public CitiesController(IStreetParkingService streetParkingService)
        {
            _streetParkingService = streetParkingService ?? throw new ArgumentNullException(nameof(streetParkingService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCities([FromQuery] string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _streetParkingService.GetCitiesAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityDto> GetCity(int id, bool includePointsOfInterest = false)
        {
            var result = StreetParkingStore.Current.Cities.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
