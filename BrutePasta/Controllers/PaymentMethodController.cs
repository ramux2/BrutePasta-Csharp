using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using Microsoft.EntityFrameworkCore;
using BrutePasta.Data;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentMethodController : ControllerBase
{
    private BrutePastaDbContext _context;
    private readonly ILogger<PaymentMethodController> _logger;
    public PaymentMethodController(BrutePastaDbContext context, ILogger<PaymentMethodController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet()]
    [Route("paymentMethods")]
    public async Task<ActionResult<IEnumerable<PaymentMethod>>> Get()
    {
        if (_context.PaymentMethod is null)
            return NotFound();
        return await _context.PaymentMethod.ToListAsync();
    }

    [HttpGet()]
    [Route("paymentMethod/{name}")]
    public async Task<ActionResult<PaymentMethod>> SearchName([FromRoute] string name)
    {
        if (_context.PaymentMethod is null)
            return NotFound();
        var paymentMethod = await _context.PaymentMethod.FindAsync(name);
        if (paymentMethod is null)
            return NotFound();
        return paymentMethod;
    }

    [HttpPost]
    [Route("paymentMethod")]
    public async Task<ActionResult<PaymentMethod>> Insert(PaymentMethod paymentMethod)
    {
        _context.PaymentMethod.Add(paymentMethod);
        await _context.SaveChangesAsync();
        return Created("", paymentMethod);
    }

    [HttpPut()]
    [Route("paymentMethod")]
    public async Task<ActionResult> Update(PaymentMethod paymentMethod)
    {
        if (_context is null)
            return NotFound();

        if (_context.PaymentMethod is null)
            return NotFound();

        var existingPaymentMethod = await _context.PaymentMethod.FindAsync(paymentMethod.PaymentMethodId);

        if (existingPaymentMethod is null)
            return NotFound();

        // Atualize os atributos do método de pagamento com base nos valores fornecidos em 'paymentMethod'.
        // Exemplo: existingPaymentMethod.Description = paymentMethod.Description;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    [Route("paymentMethod/{name}")]
    public async Task<ActionResult> UpdateAttributes(int paymentMethodId, [FromForm] string name)
    {
        if (_context is null)
            return NotFound();

        if (_context.PaymentMethod is null)
            return NotFound();

        var existingPaymentMethod = await _context.PaymentMethod.FindAsync(name);

        if (existingPaymentMethod is null)
            return NotFound();

        // Atualize os atributos do método de pagamento individualmente com base nos valores fornecidos.
        existingPaymentMethod.Name = name;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("paymentMethod/{name}")]
    public async Task<ActionResult> Delete(int paymentMethodId)
    {
        if (_context is null)
            return NotFound();

        if (_context.PaymentMethod is null)
            return NotFound();

        var existingPaymentMethod = await _context.PaymentMethod.FindAsync(paymentMethodId);

        if (existingPaymentMethod is null)
            return NotFound();

        _context.Remove(existingPaymentMethod);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
