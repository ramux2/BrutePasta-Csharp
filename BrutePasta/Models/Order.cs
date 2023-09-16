using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;
public class Order
{
    [Key]
    private int _orderId;
    private List<Item> _items;
    private Client _client;
    private Motoboy _motoboy;
    private DateTime _paymentDate;
    private float _totalValue;
    
    public int OrderId
    {
        get => _orderId;
        set => _orderId = value;
    }

    public List<Item> Items
    {
        get => _items;
        set => _items = value;
    }

    public Client Client
    {
        get => _client;
        set => _client = value;
    }

    public Motoboy Motoboy
    {
        get => _motoboy;
        set => _motoboy = value;
    }
    public DateTime PaymentDate
    {
        get => _paymentDate;
        set => _paymentDate = value;
    }

    public float TotalValue
    {
        get => _totalValue;
        set => _totalValue = value;
    }

    public Order()
    {
        _items = null;
        _client = null;
    }

    public Order(int orderId, Client client, List<Item> items, Motoboy motoboy, DateTime paymentDate, float totalValue)
    {
        _orderId = orderId;
        _client = client;
        _items = items;
        _paymentDate = paymentDate;
        _motoboy = motoboy;
        _totalValue = totalValue;
    }

    public static float calculateSubtotal(Item item)
    {
        return item.Product.Price * item.Quantity;
    }

    public static float calculaTotal(List<Item> items)
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