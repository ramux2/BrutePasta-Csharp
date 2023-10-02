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
            string clientCpf = order.Client.Cpf; // Suponha que ClientId seja a chave primária do Client
            Client existingClient = await _context.Client.FirstOrDefaultAsync(x => x.Cpf == clientCpf);

            if (existingClient is null)
                return BadRequest($"Client com CPF {clientCpf} não encontrado.");

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
                    string productName = item.Product.Name; // Suponha que ProductId seja a chave primária do Produto
                    Product existingProduct = await _context.Product.FindAsync(productName);

                    if (existingProduct is null)
                        return BadRequest($"Produto {productName} não encontrado."); // Lidar com o caso em que o Produto não foi encontrado

                    item.Product = existingProduct; // O Produto existe, associe-o ao item do pedido
                }
            }

            // Verifique se o Motoboy já existe no banco de dados
            string deliveryManCpf = order.DeliveryMan.Cpf; // Suponha que MotoboyId seja a chave primária do Motoboy
            DeliveryMan existingMotoboy = await _context.DeliveryMan.FindAsync(deliveryManCpf);

            if (existingMotoboy is null)
                return BadRequest($"Motoboy com CPF {deliveryManCpf} não encontrado.");

            order.DeliveryMan = existingMotoboy;

            // Verifique se o PaymentMethod já existe no banco de dados
            int paymentMethodId = order.Payment.PaymentMethod.PaymentMethodId; // Suponha que PaymentMethodId seja a chave primária do PaymentMethod
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
