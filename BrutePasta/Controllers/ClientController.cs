using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using BrutePasta.Data;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private BrutePastaDbContext _context;
    private readonly ILogger<ClientController> _logger;
    public ClientController(BrutePastaDbContext context, ILogger<ClientController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet()]
    [Route("clients")]
    public async Task<ActionResult<IEnumerable<Client>>> Get()
    {
        if (_context.Client is null)
            return NotFound();
        return await _context.Client.ToListAsync();
    }

    [HttpGet()]
    [Route("client/{cpf}")]
    public async Task<ActionResult<Client>> SearchCpf([FromRoute] string cpf)
    {
        if (_context.Client is null)
            return NotFound();
        var client = await _context.Client.FindAsync(cpf);
        if (client is null)
            return NotFound();
        return client;
    }

    [HttpPost]
    [Route("client")]
    public async Task<ActionResult<Client>> Insert(Client client)
    {
        if (!Client.IsCpf(client.Cpf))
            return BadRequest("CPF inválido!");

        _context.Client.Add(client);
        await _context.SaveChangesAsync();

        return Created("", client);
    }
}
