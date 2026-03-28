using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackingServices.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : Controller
    {
        [Authorize(Roles = "Manager")]
        [HttpGet("gps")]
        public IActionResult GetGpsData()
        {
            var random = new Random();

            var data = new[]
            {
            new {
            TruckId = "1001",
            Latitude = 31.3260 + random.NextDouble() / 100,
            Longitude = 75.5762 + random.NextDouble() / 100,
            Location = "Jalandhar",
            Status = "Idle",
            Timestamp = DateTime.UtcNow
            },

            new {
            TruckId = "1002",
            Latitude = 13.0827 + random.NextDouble() / 100,
            Longitude = 80.2707 + random.NextDouble() / 100,
            Location = "Chennai",
            Status = "Delivered",
            Timestamp = DateTime.UtcNow
            },
            new {
            TruckId = "1003",
            Latitude = 22.5726 + random.NextDouble() / 100,
            Longitude = 88.3639 + random.NextDouble() / 100,
            Location = "Kolkata",
            Status = "In Transit",
            Timestamp = DateTime.UtcNow
            },
            new {
            TruckId = "1004",
            Latitude = 30.7333 + random.NextDouble() / 100,
            Longitude = 76.7794 + random.NextDouble() / 100,
            Location = "Chandigarh",
            Status = "In Transit",
            Timestamp = DateTime.UtcNow
            },
            new {
            TruckId = "1005",
            Latitude = 28.7041 + random.NextDouble() / 100,
            Longitude = 77.1025 + random.NextDouble() / 100,
            Location = "Delhi",
            Status = "Delivered",
            Timestamp = DateTime.UtcNow
            },
           
            new {
            TruckId = "1006",
            Latitude = 19.0760 + random.NextDouble() / 100,
            Longitude = 72.8777 + random.NextDouble() / 100,
            Location = "Mumbai",
            Status = "In Transit",
            Timestamp = DateTime.UtcNow
            },
           
           
            new {
            TruckId = "1007",
            Latitude = 12.9716 + random.NextDouble() / 100,
            Longitude = 77.5946 + random.NextDouble() / 100,
            Location = "Bangalore",
            Status = "Idle",
            Timestamp = DateTime.UtcNow
            }
            };
            return Ok(data);
        }
    }
}
