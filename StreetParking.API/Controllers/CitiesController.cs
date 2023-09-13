using Microsoft.AspNetCore.Mvc;

namespace StreetParking.API.Controllers
{
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet("api/cities")]
        public JsonResult GetCities()
        {

            return new JsonResult(
                new List<object>
                {
                    new {Id= 1, Name = "Miramar"},
                    new {Id= 2, Name = "Necochea"}
                });
        }
    }
}
