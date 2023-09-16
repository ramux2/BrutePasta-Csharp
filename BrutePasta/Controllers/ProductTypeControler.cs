using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductTypeController : ControllerBase
{
    private readonly ILogger<ProductTypeController> _logger;
    public ProductTypeController(ILogger<ProductTypeController> logger)
    {
        _logger = logger;
    }

    private static List<ProductType> productTypes = new();

    [HttpGet()]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok(productTypes);
    }

    [HttpPost]
    [Route("insert")]
    public IActionResult Insert(ProductType productType)
    {
        productTypes.Add(productType);
        return Created("", productType);
    }
}
