using BrutePasta.Data;
using BrutePasta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private BrutePastaDbContext _context;
        private readonly ILogger<OrderController> _logger;
        public OrderController(BrutePastaDbContext context, ILogger<OrderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        [Route("orders")]
        public async Task<ActionResult<IEnumerable<RestaurantOrder>>> Get()
        {
            if (_context.RestaurantOrder is null)
                return NotFound();
            return await _context.RestaurantOrder.ToListAsync();
        }

        [HttpPost]
        [Route("order")]
        public async Task<ActionResult<RestaurantOrder>> Insert(RestaurantOrder order)
        {
            // Verifique se o Client já existe no banco de dados
            int clientId = order.Client.Id;
            Client existingClient = await _context.Client.FirstOrDefaultAsync(x => x.Id == clientId);

            if (existingClient is null)
                return BadRequest($"Client com ID {clientId} não encontrado.");

            order.Client = existingClient;
            
            // Verifique se a lista de itens não é nula ou vazia
            if (order.Items == null || order.Items.Count == 0)
                return BadRequest("A lista de itens está vazia.");

            // Itere sobre os itens do pedido e associe os produtos existentes
            foreach (var item in order.Items)
            {
                // Verifique se o item tem um Produto associado
                if (item.Product != null)
                {
                    // Obtenha o Produto existente pelo ID
                    int productId = item.Product.Id; // Suponha que ProductId seja a chave primária do Produto
                    Product existingProduct = await _context.Product.FindAsync(productId);

                    if (existingProduct == null || (existingProduct.QtyAvailable + item.Quantity) < 0)
                        return BadRequest("Quantidade indisponível");
                    
                    if (existingProduct is null)
                        return BadRequest($"Produto {productId} não encontrado."); // Lidar com o caso em que o Produto não foi encontrado

                    existingProduct.QtyAvailable -= item.Quantity;
                    item.Product = existingProduct; // O Produto existe, associe-o ao item do pedido
                }
            }

            // Verifique se a lista de motoboys não é nula ou vazia
            if (_context.DeliveryMan is null || !_context.DeliveryMan.Any())
                return BadRequest("Não há motoboys cadastrados.");

            // Gere um índice aleatório com base no número de motoboys disponíveis
            var random = new Random();
            int randomIndex = random.Next(0, _context.DeliveryMan.Count());

            // Selecione o motoboy correspondente ao índice aleatório gerado
            var selectedDeliveryMan = _context.DeliveryMan.Skip(randomIndex).FirstOrDefault();

            if (selectedDeliveryMan is null)
                return BadRequest("Motoboy selecionado não encontrado.");

            // Incremente a taxa de pedido (OrderTax) para o motoboy selecionado
            selectedDeliveryMan.OrderTax += 20;

            // Associe o motoboy selecionado ao pedido
            order.DeliveryMan = selectedDeliveryMan;

            // Verifique se o PaymentMethod já existe no banco de dados
            int paymentMethodId = order.Payment.PaymentMethod.Id; // Suponha que PaymentMethodId seja a chave primária do PaymentMethod
            PaymentMethod existingPaymentMethod = await _context.PaymentMethod.FindAsync(paymentMethodId);

            if (existingPaymentMethod != null)
            {
                // O PaymentMethod existe, associe-o ao seu objeto Payment
                order.Payment.PaymentMethod = existingPaymentMethod;
            }
            else
            {
                // Lidar com o caso em que o PaymentMethod não foi encontrado
                return BadRequest($"PaymentMethod com ID {paymentMethodId} não encontrado.");
            }

            // Calcule o valor total do pedido
            order.Payment.Value = calculateTotal(order.Items);

            // Adicione o pedido e os itens ao contexto e salve as alterações
            _context.RestaurantOrder.Add(order);
            await _context.SaveChangesAsync();

            return Created("", order);
        }

        [HttpPut()]
        [Route("order")]
        public async Task<ActionResult> Update(RestaurantOrder order)
        {
            if (_context is null)
                return NotFound();

            if (_context.RestaurantOrder is null)
                return NotFound();

            RestaurantOrder existingOrder = await _context.RestaurantOrder.FindAsync(order.Id);

            if (existingOrder is null)
                return NotFound();

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("order/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (_context is null)
                return NotFound();

            if (_context.RestaurantOrder is null)
                return NotFound();

            var existingOrder = await _context.RestaurantOrder.FindAsync(id);

            if (existingOrder is null)
                return NotFound();

            _context.Remove(existingOrder);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public static float calculateSubtotal(Item item)
        {
            return item.Product.Price * item.Quantity;
        }

        public static float calculateTotal(List<Item> items)
        {
            float total = 0;
            foreach (Item item in items)
            {
                total += calculateSubtotal(item);
            }
            total += 20;
            return total;
        }
    }
}
