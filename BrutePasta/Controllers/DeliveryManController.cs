using BrutePasta.Data;
using BrutePasta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryManController : ControllerBase
    {
        private BrutePastaDbContext _context;
        private readonly ILogger<DeliveryManController> _logger;
        public DeliveryManController(BrutePastaDbContext context, ILogger<DeliveryManController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        [Route("deliveryMen")]
        public async Task<ActionResult<IEnumerable<DeliveryMan>>> Get()
        {
            if (_context.DeliveryMan is null)
                return NotFound();
            return await _context.DeliveryMan.ToListAsync();
        }

        [HttpGet()]
        [Route("deliveryMan/{cpf}")]
        public async Task<ActionResult<DeliveryMan>> Search([FromRoute] string cpf)
        {
            if (_context.DeliveryMan is null)
                return NotFound();
            var motoboy = await _context.DeliveryMan.FindAsync(cpf);
            if (motoboy is null)
                return NotFound();
            return motoboy;
        }

        [HttpPost]
        [Route("deliveryMan")]
        public async Task<ActionResult<DeliveryMan>> Insert(DeliveryMan deliveryMan)
        {
            _context.DeliveryMan.Add(deliveryMan);
            await _context.SaveChangesAsync();

            return Created("", deliveryMan);
        }

        [HttpPut()]
        [Route("deliveryMan")]
        public async Task<ActionResult> Update(DeliveryMan deliveryMan)
        {
            if (_context is null)
                return NotFound();

            if (_context.DeliveryMan is null)
                return NotFound();

            var existingDeliveryMan = await _context.DeliveryMan.FindAsync(deliveryMan.Cpf);

            if (existingDeliveryMan is null)
                return NotFound();

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch()]
        [Route("deliveryMan/{cpf}")]
        public async Task<ActionResult> UpdateAttributes(string cpf,[FromForm] string name)
        {
            if (_context is null)
                return NotFound();

            if (_context.DeliveryMan is null)
                return NotFound();

            var existingDeliveryMan = await _context.DeliveryMan.FindAsync(cpf);

            if (existingDeliveryMan is null)
                return NotFound();

            existingDeliveryMan.Name = name;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("deliveryMan/{cpf}")]
        public async Task<ActionResult> Delete(string cpf)
        {
            if (_context is null)
                return NotFound();

            if (_context.DeliveryMan is null)
                return NotFound();

            var existingDeliveryMan = await _context.DeliveryMan.FindAsync(cpf);

            if (existingDeliveryMan is null)
                return NotFound();

            _context.Remove(existingDeliveryMan);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
