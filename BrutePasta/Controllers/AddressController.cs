using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using BrutePasta.Data;
using Microsoft.EntityFrameworkCore;

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
}
