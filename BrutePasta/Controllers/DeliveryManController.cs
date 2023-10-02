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
    }
}
