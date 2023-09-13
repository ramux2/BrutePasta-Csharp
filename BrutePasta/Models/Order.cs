using Microsoft.AspNetCore.Http.Features;

namespace BrutePasta.Models;
public class Order
{
    private Item _items;
    private Client _client;
    private Motoboy _motoboy;
    private float _totalValue;
    

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

    public Order(Client client, Item item, float totalValue)
    {
        _client = client;
        _items = item;
        _totalValue = totalValue;
    }

    // Sortear entregador
}