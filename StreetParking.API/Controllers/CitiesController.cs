using Microsoft.AspNetCore.Mvc;

namespace StreetParking.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(StreetParkingStore.Current.Cities);
        }
    }
}
