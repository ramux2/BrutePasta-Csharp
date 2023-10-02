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
    [Route("vehicle/{licensePlate}")]
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
    [Route("vehicle")]
    public async Task<ActionResult<Vehicle>> Insert(Vehicle vehicle)
    {
        // Obtenha o vehicleId do JSON de entrada
        string deliveryManCpf = vehicle.DeliveryMan.Cpf; // Assumindo que o JSON possui um objeto Vehicle aninhado

        // Verifique se o Vehicle com o vehicleId fornecido existe no banco de dados
        DeliveryMan existingDeliveryMan = await _context.DeliveryMan.FirstOrDefaultAsync(x => x.Cpf == deliveryManCpf);

        if (existingDeliveryMan is null)
            return BadRequest("DeliveryMan not found");

        if (!Vehicle.PlateValidation(vehicle.LicensePlate))
            return BadRequest("Placa inválida!");

        _context.Vehicle.Add(vehicle);
        await _context.SaveChangesAsync();

        return Created("", vehicle);
    }
}
