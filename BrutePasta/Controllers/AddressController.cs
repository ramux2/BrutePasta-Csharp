using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using BrutePasta.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private BrutePastaDbContext _context;
    private readonly ILogger<AddressController> _logger;
    public AddressController(BrutePastaDbContext context, ILogger<AddressController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet()]
    [Route("addresses")]
    public async Task<ActionResult<IEnumerable<Address>>> Get()
    {
        if (_context.Address is null)
            return NotFound();
        return await _context.Address.ToListAsync();
    }

    [HttpPost]
    [Route("address")]
    public async Task<ActionResult<Address>> Insert(Address address)
    {
        _context.Address.Add(address);
        await _context.SaveChangesAsync();
        return Created("", address);
    }

    [HttpPut()]
    [Route("address")]
    public async Task<ActionResult> Update(Address address)
    {
        if (_context is null)
            return NotFound();

        if (_context.Address is null)
            return NotFound();

        var existingAddress = await _context.Address.AsNoTracking().FirstOrDefaultAsync(x => x.Id == address.Id);

        if (existingAddress is null)
            return NotFound();

        _context.Entry(address).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("address/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context is null)
            return NotFound();

        if (_context.Address is null)
            return NotFound();

        var existingAddress = await _context.Address.FindAsync(id);

        if (existingAddress is null)
            return NotFound();

        _context.Remove(existingAddress);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
