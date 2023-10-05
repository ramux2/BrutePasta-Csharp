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
            int paymentMethodId = payment.PaymentMethod.Id; // Assumindo que o JSON possui um objeto PaymentMethod aninhado

            // Verifique se PaymentMethod com o paymentMethodId fornecido existe no banco de dados
            PaymentMethod existingPaymentMethod = await _context.PaymentMethod.FirstOrDefaultAsync(v => v.Id == paymentMethodId);

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

            var existingPayment = await _context.Payment.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payment.Id);

            if (existingPayment is null)
                return NotFound();

            _context.Entry(payment).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("payment/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (_context is null)
                return NotFound();

            if (_context.Payment is null)
                return NotFound();

            var existingPayment = await _context.Payment.FindAsync(id);

            if (existingPayment is null)
                return NotFound();

            _context.Remove(existingPayment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
