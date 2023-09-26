using BrutePasta.Data;
using BrutePasta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoboyController : ControllerBase
    {
        private BrutePastaDbContext _context;
        private readonly ILogger<MotoboyController> _logger;
        public MotoboyController(BrutePastaDbContext context, ILogger<MotoboyController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        [Route("motoboys")]
        public async Task<ActionResult<IEnumerable<Motoboy>>> Get()
        {
            if (_context.Motoboy is null)
                return NotFound();
            return await _context.Motoboy.ToListAsync();
        }

        [HttpGet()]
        [Route("motoboy/{cpf}")]
        public async Task<ActionResult<Motoboy>> Search([FromRoute] string cpf)
        {
            if (_context.Motoboy is null)
                return NotFound();
            var motoboy = await _context.Motoboy.FindAsync(cpf);
            if (motoboy is null)
                return NotFound();
            return motoboy;
        }

        [HttpPost]
        [Route("motoboy")]
        public async Task<ActionResult<Motoboy>> Insert(Motoboy motoboy)
        {
            // Obtenha o vehicleId do JSON de entrada
            int vehicleId = motoboy.Vehicle?.VehicleId ?? 0; // Assumindo que o JSON possui um objeto Vehicle aninhado

            // Verifique se o Vehicle com o vehicleId fornecido existe no banco de dados
            Vehicle existingVehicle = await _context.Vehicle.FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            /*if (!Vehicle.PlateValidation(vehicle.LicensePlate))
                return BadRequest("Placa inválida!");*/

            if (existingVehicle is null)
                return BadRequest("Vehicle not found");

            // O Vehicle existe, agora crie o Motoboy associando o Vehicle existente
            motoboy.Vehicle = existingVehicle;
            _context.Motoboy.Add(motoboy);
            await _context.SaveChangesAsync();

            return Created("", motoboy);
            
        }
    }
}
