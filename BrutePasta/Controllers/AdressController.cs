using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class AdressController : ControllerBase
{
    private readonly ILogger<AdressController> _logger;
    public AdressController(ILogger<AdressController> logger)
    {
        _logger = logger;
    }

    private static List<Address> adresses = new();

    [HttpGet()]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok(adresses);
    }

    [HttpPost]
    [Route("insert")]
    public IActionResult Insert(Address adress)
    {
        adresses.Add(adress);
        return Created("", adress);
    }
}
