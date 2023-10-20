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
            var products = await _context.Product
                .Include(p => p.ProductType)
                .ToListAsync();

            if (products is null)
                return NotFound();

            return products;
        }


        [HttpPost]
        [Route("product")]
        public async Task<ActionResult<Product>> Insert(Product product)
        {
            // Obtenha productTypeId do JSON de entrada
            int productTypeId = product.ProductType.Id; // Assumindo que o JSON possui um objeto ProductType aninhado

            // Verifique se ProductType com o productTypeId fornecido existe no banco de dados
            ProductType existingProductType = await _context.ProductType.FirstOrDefaultAsync(v => v.Id == productTypeId);

            if (existingProductType is null)
                return BadRequest("ProductType not found");

            // O ProductType existe, agora crie o Product associando o ProductType existente
            product.ProductType = existingProductType;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Created("", product);
        }

        [HttpPut()]
        [Route("product")]
        public async Task<ActionResult> Update(Product product)
        {
            if (_context is null)
                return NotFound();

            if (_context.Product is null)
                return NotFound();

            var existingProduct = await _context.Product.AsNoTracking().FirstOrDefaultAsync(x => x.Id == product.Id);

            if (existingProduct is null)
                return NotFound();

            // Atualize os atributos do produto com base nos valores fornecidos em 'product'.
            // Exemplo: existingProduct.Price = product.Price;

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("product/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (_context is null)
                return NotFound();

            if (_context.Product is null)
                return NotFound();

            var existingProduct = await _context.Product.FindAsync(id);

            if (existingProduct is null)
                return NotFound();

            _context.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
