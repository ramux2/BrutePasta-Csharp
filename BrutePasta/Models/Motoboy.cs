using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Motoboy
{
    [Key]
    private int _motoboyId;
    private string _cpf;
    private string _name;
    private float _orderTax;
    private int _vehicleId;
    private Vehicle? _vehicle;

    public int MotoboyId
    {
        get => _motoboyId;
        set => _motoboyId = value;
    }

    public string Cpf
    {
        get => _cpf;
        set => _cpf = value;
    }

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

    public int VehicleId
    {
        get => _vehicleId;
        set => _vehicleId = value;
    }

    public Vehicle? Vehicle
    {
        get => _vehicle;
        set => _vehicle = value;
    }

    public Motoboy()
    {
        _cpf = string.Empty;
        _name = string.Empty;
    }

    public Motoboy(int motoboyId, string cpf, string name, float orderTax, int vehicleId)
    {
        _motoboyId = motoboyId;
        _cpf = cpf;
        _name = name;
        _orderTax = orderTax;
        _vehicleId = vehicleId;
    }
}
