using Microsoft.AspNetCore.Mvc;
using CloseApproach.Api.Models;

namespace CloseApproach.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CloseApproachController : ControllerBase
{
    // Data
    private static readonly List<Asteroid> asteroids = new List<Asteroid>()
    {
        new Asteroid
        {
            Id = 1,
            Diameter = 120.0,
            CloseApproach = new CloseApproachData
            {
                CloseApproachDate = new DateTime(2025, 12, 24),
                LunarDistance = 100.0
            }
        },
        new Asteroid
        {
            Id = 2,
            Diameter = 141.0,
            CloseApproach = new CloseApproachData
            {
                CloseApproachDate = new DateTime(2025, 04, 01),
                LunarDistance = 3.0
            }
        },
        new Asteroid
        {
            Id = 3,
            Diameter = 500.0,
            CloseApproach = new CloseApproachData
            {
                CloseApproachDate = new DateTime(2035, 01, 21),
                LunarDistance = 400.0
            }
        },
        new Asteroid
        {
            Id = 4,
            Diameter = 25.0,
            CloseApproach = new CloseApproachData
            {
                CloseApproachDate = new DateTime(2025, 03, 03),
                LunarDistance = 1.0
            }
        },
        new Asteroid
        {
            Id = 5,
            Diameter = 1000.0,
            CloseApproach = new CloseApproachData
            {
                CloseApproachDate = new DateTime(2025, 06, 01),
                LunarDistance = 5.0
            }
        }
    };

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Asteroid>), StatusCodes.Status200OK)]
    public IActionResult GetAllAsteroids()
    {
        var sortedAsteroids = asteroids.OrderBy(a => a.Id);

        return Ok(sortedAsteroids);
    }

    [HttpGet("hazardous")]
    [ProducesResponseType(typeof(IEnumerable<Asteroid>), StatusCodes.Status200OK)]
    public IActionResult GetHazardousAsteroids()
    {
        var hazardousAsteroids = asteroids.Where(a => a.IsHazardous == true).ToList();

        return Ok(hazardousAsteroids);
    }

    [HttpGet("closest")]
    [ProducesResponseType(typeof(Asteroid), StatusCodes.Status200OK)]
    public IActionResult GetClosestAsteroid()
    {
        DateTime now = DateTime.Now;

        var closestAsteroid = asteroids.OrderBy(a => a.CloseApproach.LunarDistance).First();

        return Ok(closestAsteroid);
    }
}
