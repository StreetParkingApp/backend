using Microsoft.AspNetCore.Mvc;
using StreetParking.API.Models;

namespace StreetParking.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {

            var city = StreetParkingStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointOfInterests);

        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointsOfInterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId, int pointOfInterestId)
        {

            var city = StreetParkingStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(x => x.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {

            var city = StreetParkingStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = StreetParkingStore.Current.Cities.SelectMany(c => c.PointOfInterests).Max(x => x.Id);

            var finalPointOfInterest = new PointOfInterestDto
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
            };

            city.PointOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointsOfInterest", 
                new { cityId , pointOfInterestId = finalPointOfInterest.Id}, finalPointOfInterest);
        }
    }
}
