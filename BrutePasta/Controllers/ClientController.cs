using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    private static List<Client> clients = new();

    [HttpGet()]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok(clients);
    }

    [HttpGet()]
    [Route("search/{cpf}")]
    public IActionResult Search([FromRoute] string cpf)
    {
        Client client = clients.Find(x => x.Cpf == cpf);
        if (client is not null)
            return Ok(client);
        else
            return NotFound();
    }

    [HttpPost]
    [Route("insert")]
    public IActionResult Insert(Client client)
    {
        clients.Add(client);
        return Created("", client);
    }
}
