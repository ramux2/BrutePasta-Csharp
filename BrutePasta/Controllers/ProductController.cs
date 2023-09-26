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
        public ProductController(BrutePastaDbContext context, ILogger<ProductController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet()]
        [Route("products")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            if (_context.Product is null)
                return NotFound();
            return await _context.Product.ToListAsync();
        }

        [HttpPost]
        [Route("product")]
        public async Task<ActionResult<Product>> Insert(Product product)
        {
            // Obtenha productTypeId do JSON de entrada
            int productTypeId = product.ProductType?.ProductTypeId ?? 0; // Assumindo que o JSON possui um objeto ProductType aninhado

            // Verifique se ProductType com o productTypeId fornecido existe no banco de dados
            ProductType existingProductType = await _context.ProductType.FirstOrDefaultAsync(v => v.ProductTypeId == productTypeId);

            if (existingProductType is null)
                return BadRequest("ProductType not found");

            // O ProductType existe, agora crie o Product associando o ProductType existente
            product.ProductType = existingProductType;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Created("", product);
        }
    }
}
