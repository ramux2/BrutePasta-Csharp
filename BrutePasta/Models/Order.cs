using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BrutePasta.Models;
public class Order
{
    private int _orderId;
    private Item _items;
    private Client _client;
    private Motoboy _motoboy;
    private float _totalValue;
    
    public int OrderId
    {
        get => _orderId;
        set => _orderId = value;
    }

    public Item Items
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

    public Order(int orderId, Client client, Item item, float totalValue)
    {
        _orderId = orderId;
        _client = client;
        _items = item;
        _totalValue = totalValue;
    }

    public static float calculateSubtotal(Item item, Product product)
    {
        return product.Price * item.Quantity;
    }

    public static float calculaTotal(List<Item> items)
    {
        float total = 0;
        foreach (Item item in items)
        {
            total += calculateSubtotal(item, item.Product);
        }
        total += 20;
        return total;
    }
}