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
    public VehicleController(BrutePastaDbContext context, ILogger<VehicleController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet()]
    [Route("vehicles")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
    {
        if (_context.Vehicle is null) 
            return NotFound();
        return await _context.Vehicle.ToListAsync();
    }

    [HttpGet()]
    [Route("vehicle/{id}")]
    public async Task<ActionResult<Vehicle>> Search([FromRoute] int id)
    {
        if(_context.Vehicle is null)
            return NotFound();
        var vehicle = await _context.Vehicle.FindAsync(id);
        if (vehicle is null)
            return NotFound();
        return vehicle;
    }

    [HttpPost]
    [Route("vehicle")]
    public async Task<ActionResult<Vehicle>> Insert(Vehicle vehicle)
    {
        // Obtenha o vehicleId do JSON de entrada
        int deliveryManId = vehicle.DeliveryMan.Id; // Assumindo que o JSON possui um objeto Vehicle aninhado

        // Verifique se o Vehicle com o vehicleId fornecido existe no banco de dados
        DeliveryMan existingDeliveryMan = await _context.DeliveryMan.AsNoTracking().FirstOrDefaultAsync(x => x.Id == deliveryManId);

        _context.Entry(vehicle).State = EntityState.Modified;

        if (existingDeliveryMan is null)
            return BadRequest("DeliveryMan not found");

        if (!Vehicle.PlateValidation(vehicle.LicensePlate))
            return BadRequest("Placa inválida!");

        _context.Vehicle.Add(vehicle);
        await _context.SaveChangesAsync();

        return Created("", vehicle);
    }

    [HttpPut()]
    [Route("vehicle")]
    public async Task<ActionResult> Update(Vehicle vehicle)
    {
        if (_context is null)
            return NotFound();

        if (_context.Vehicle is null)
            return NotFound();

        var existingVehicle = await _context.Vehicle.AsNoTracking().FirstOrDefaultAsync(x => x.Id == vehicle.Id);

        if (existingVehicle is null)
            return NotFound();

        _context.Entry(vehicle).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("vehicle/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context is null)
            return NotFound();

        if (_context.Vehicle is null)
            return NotFound();

        var existingVehicle = await _context.Vehicle.FindAsync(id);

        if (existingVehicle is null)
            return NotFound();

        _context.Remove(existingVehicle);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
