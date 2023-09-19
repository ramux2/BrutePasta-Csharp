using BrutePasta.Data;
using BrutePasta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private BrutePastaDbContext _context;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public ProductController(BrutePastaDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            if (_context.Product is null)
                return NotFound();
            return await _context.Product.ToListAsync();
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<Product>> Insert(Product product)
        {
            // Dar um get no Vehicle e depois associar o Vehicle com motoboy
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Created("", product);
        }
    }
}
