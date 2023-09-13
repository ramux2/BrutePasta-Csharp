using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Motoboy
{
    private string _name;
    private float _orderTax;
    private Vehicle _vehicle;

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

    public Vehicle Vehicle
    {
        get => _vehicle;
        set => _vehicle = value;
    }

    public Motoboy()
    {
        _name = string.Empty;
    }
}
