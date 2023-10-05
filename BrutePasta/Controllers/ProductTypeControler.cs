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
    [Route("productType/{id}")]
    public async Task<ActionResult<ProductType>> SearchName([FromRoute] int id)
    {
        if (_context.ProductType is null)
            return NotFound();
        var productType = await _context.ProductType.FindAsync(id);
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

    [HttpPut()]
    [Route("productType")]
    public async Task<ActionResult> Update(ProductType productType)
    {
        if (_context is null)
            return NotFound();

        if (_context.ProductType is null)
            return NotFound();

        var existingProductType = await _context.ProductType.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productType.Id);

        if (existingProductType is null)
            return NotFound();

        _context.Entry(productType).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("productType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context is null)
            return NotFound();

        if (_context.ProductType is null)
            return NotFound();

        var existingProductType = await _context.ProductType.FindAsync(id);

        if (existingProductType is null)
            return NotFound();

        _context.Remove(existingProductType);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
