using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StreetParking.API.Entities;
using StreetParking.API.Models;
using StreetParking.API.Services;

namespace StreetParking.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly IStreetParkingService _streetParkingService;
        private readonly IMapper _mapper;

        public CitiesController(IStreetParkingService streetParkingService, IMapper mapper)
        {
            _streetParkingService = streetParkingService ?? 
                throw new ArgumentNullException(nameof(streetParkingService));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
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
        public async Task<IActionResult> GetCity(int id)
        {
            var result = await _streetParkingService.GetCityById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreateCity(CityForCreationDto city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (city.Name != null && await _streetParkingService.CityExistByNameAsync(city.Name))
            {
                return BadRequest($"City with {city.Name} name already exists");
            }

            var finalCity = _mapper.Map<City>(city);

            await _streetParkingService.AddCityAsync(finalCity);

            await _streetParkingService.SaveChangesAsync();

            return Ok(finalCity);
        }
    }
}
