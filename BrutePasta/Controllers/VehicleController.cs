using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;
    public VehicleController(ILogger<VehicleController> logger)
    {
        _logger = logger;
    }

    private static List<Vehicle> vehicles = new();

    [HttpGet()]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok(vehicles);
    }

    [HttpGet()]
    [Route("search/{licensePlate}")]
    public IActionResult Search([FromRoute] string licensePlate)
    {
        Vehicle vehicle = vehicles.Find(x => x.LicensePlate == licensePlate);
        if (vehicle is not null)
            return Ok(vehicle);
        else
            return NotFound();
    }

    [HttpPost]
    [Route("insert")]
    public IActionResult Insert(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        return Created("", vehicle);
    }
}
