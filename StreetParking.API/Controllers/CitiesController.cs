using Microsoft.AspNetCore.Mvc;
using StreetParking.API.Models;

namespace StreetParking.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(new JsonResult(StreetParkingStore.Current.Cities));
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
