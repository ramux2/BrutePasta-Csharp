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
        public MotoboyController(ILogger<MotoboyController> logger)
        {
            _logger = logger;
        }

        public MotoboyController(BrutePastaDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<Motoboy>>> Get()
        {
            if (_context.Motoboy is null)
                return NotFound();
            return await _context.Motoboy.ToListAsync();
        }

        [HttpGet()]
        [Route("search/{cpf}")]
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
        [Route("insert")]
        public async Task<ActionResult<Motoboy>> Insert(Motoboy motoboy)
        {
            // Dar um get no Vehicle e depois associar o Vehicle com motoboy
            _context.Motoboy.Add(motoboy);
            await _context.SaveChangesAsync();

            return Created("", motoboy);
        }
    }
}
