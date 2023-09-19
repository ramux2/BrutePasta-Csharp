using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using BrutePasta.Data;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class AdressController : ControllerBase
{
    private BrutePastaDbContext _context;
    private readonly ILogger<AdressController> _logger;
    public AdressController(ILogger<AdressController> logger)
    {
        _logger = logger;
    }

    public AdressController(BrutePastaDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("get")]
    public async Task<ActionResult<IEnumerable<Address>>> Get()
    {
        if (_context.Address is null)
            return NotFound();
        return await _context.Address.ToListAsync();
    }

    [HttpPost]
    [Route("insert")]
    public async Task<ActionResult<Address>> Insert(Address address)
    {
        _context.Address.Add(address);
        await _context.SaveChangesAsync();
        return Created("", address);
    }
}
