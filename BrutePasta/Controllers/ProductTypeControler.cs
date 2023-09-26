using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using BrutePasta.Data;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductTypeController : ControllerBase
{
    private BrutePastaDbContext _context;
    private readonly ILogger<ProductTypeController> _logger;
    public ProductTypeController(BrutePastaDbContext context, ILogger<ProductTypeController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet()]
    [Route("productTypes")]
    public async Task<ActionResult<IEnumerable<ProductType>>> Get()
    {
        if (_context.ProductType is null)
            return NotFound();
        return await _context.ProductType.ToListAsync();
    }

    [HttpGet()]
    [Route("productType/{name}")]
    public async Task<ActionResult<ProductType>> SearchName([FromRoute] string name)
    {
        if (_context.ProductType is null)
            return NotFound();
        var productType = await _context.ProductType.FindAsync(name);
        if (productType is null)
            return NotFound();
        return productType;
    }

    [HttpPost]
    [Route("productType")]
    public async Task<ActionResult<ProductType>> Insert(ProductType productType)
    {
        _context.ProductType.Add(productType);
        await _context.SaveChangesAsync();
        return Created("", productType);
    }
}
