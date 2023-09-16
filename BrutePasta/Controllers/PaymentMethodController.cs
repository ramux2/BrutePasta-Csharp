using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentMethodController : ControllerBase
{
    private readonly ILogger<PaymentMethodController> _logger;
    public PaymentMethodController(ILogger<PaymentMethodController> logger)
    {
        _logger = logger;
    }

    private static List<PaymentMethod> paymentMethods = new();

    [HttpGet()]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok(paymentMethods);
    }

    [HttpPost]
    [Route("insert")]
    public IActionResult Insert(PaymentMethod paymentMethod)
    {
        paymentMethods.Add(paymentMethod);
        return Created("", paymentMethod);
    }
}
