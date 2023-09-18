using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrutePasta.Models;
using BrutePasta.Data;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private BrutePastaDbContext? _context;
    private readonly ILogger<VehicleController> _logger;
    public VehicleController(ILogger<VehicleController> logger)
    {
        _logger = logger;
    }
    
    public VehicleController(BrutePastaDbContext context) 
    {
        _context = context;
    }

    [HttpGet()]
    [Route("get")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
    {
        if (_context.Vehicle is null) 
            return NotFound();
        return await _context.Vehicle.ToListAsync();
    }

    [HttpGet()]
    [Route("search/{licensePlate}")]
    public async Task<ActionResult<Vehicle>> Search([FromRoute] string licensePlate)
    {
        if(_context.Vehicle is null)
            return NotFound();
        var vehicle = await _context.Vehicle.FindAsync(licensePlate);
        if (vehicle is null)
            return NotFound();
        return vehicle;
    }

    [HttpPost]
    [Route("insert")]
    public async Task<ActionResult<Vehicle>> Insert(Vehicle vehicle)
    {
        if (!Vehicle.PlateValidation(vehicle.LicensePlate))
            return BadRequest("Placa inválida!");

        _context.Vehicle.Add(vehicle);
        await _context.SaveChangesAsync();

        return Created("GetVehicle", vehicle);
    }
}
