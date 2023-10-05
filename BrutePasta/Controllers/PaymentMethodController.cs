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
    [Route("paymentMethod/{id}")]
    public async Task<ActionResult<PaymentMethod>> SearchName([FromRoute] int id)
    {
        if (_context.PaymentMethod is null)
            return NotFound();
        var paymentMethod = await _context.PaymentMethod.FindAsync(id);
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

        var existingPaymentMethod = await _context.PaymentMethod.AsNoTracking().FirstOrDefaultAsync(x => x.Id == paymentMethod.Id);

        if (existingPaymentMethod is null)
            return NotFound();

        _context.Entry(paymentMethod).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("paymentMethod/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context is null)
            return NotFound();

        if (_context.PaymentMethod is null)
            return NotFound();

        var existingPaymentMethod = await _context.PaymentMethod.FindAsync(id);

        if (existingPaymentMethod is null)
            return NotFound();

        _context.Remove(existingPaymentMethod);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
