using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Motoboy
{
    private string _name;
    private float _orderTax;
    private List<Order> _orders;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public float OrderTax
    {
        get => _orderTax;
        set => _orderTax = value;
    }

    public List<Order> Orders
    {
        get => _orders;
        set => _orders = value;
    }

    public Motoboy()
    {
        _orders = new List<Order>();
        _name = string.Empty;
    }
}
