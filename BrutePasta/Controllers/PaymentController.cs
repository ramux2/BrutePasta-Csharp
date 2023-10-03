using BrutePasta.Data;
using BrutePasta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private BrutePastaDbContext _context;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(BrutePastaDbContext context, ILogger<PaymentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        [Route("payments")]
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            if (_context.Payment is null)
                return NotFound();
            return await _context.Payment.ToListAsync();
        }

        [HttpPost]
        [Route("payment")]
        public async Task<ActionResult<Payment>> Insert(Payment payment)
        {
            // Obtenha o paymentMethodId do JSON de entrada
            int paymentMethodId = payment.PaymentMethod?.PaymentMethodId ?? 0; // Assumindo que o JSON possui um objeto PaymentMethod aninhado

            // Verifique se PaymentMethod com o paymentMethodId fornecido existe no banco de dados
            PaymentMethod existingPaymentMethod = await _context.PaymentMethod.FirstOrDefaultAsync(v => v.PaymentMethodId == paymentMethodId);

            if (existingPaymentMethod is null)
                return BadRequest("Vehicle not found");

            // O Payment existe, agora crie o Payment associando o PaymentMethod existente
            payment.PaymentMethod = existingPaymentMethod;
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();

            return Created("", payment);
        }

        [HttpPut()]
        [Route("payment")]
        public async Task<ActionResult> Update(Payment payment)
        {
            if (_context is null)
                return NotFound();

            if (_context.Payment is null)
                return NotFound();

            var existingPayment = await _context.Payment.FindAsync(payment.PaymentId);

            if (existingPayment is null)
                return NotFound();

            // Atualize os atributos do pagamento com base nos valores fornecidos em 'payment'.
            // Exemplo: existingPayment.Amount = payment.Amount;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch()]
        [Route("payment/{paymentId}")]
        public async Task<ActionResult> UpdateAttributes(int paymentId, [FromForm] float value, [FromForm] PaymentMethod paymentMethod)
        {
            if (_context is null)
                return NotFound();

            if (_context.Payment is null)
                return NotFound();

            var existingPayment = await _context.Payment.FindAsync(paymentId);

            if (existingPayment is null)
                return NotFound();

            // Atualize os atributos do pagamento individualmente com base nos valores fornecidos.
            existingPayment.Value = value;
            existingPayment.PaymentMethod = paymentMethod;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("payment/{paymentId}")]
        public async Task<ActionResult> Delete(int paymentId)
        {
            if (_context is null)
                return NotFound();

            if (_context.Payment is null)
                return NotFound();

            var existingPayment = await _context.Payment.FindAsync(paymentId);

            if (existingPayment is null)
                return NotFound();

            _context.Remove(existingPayment);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
