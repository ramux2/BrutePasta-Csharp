using System;

public class Vehicle
{
    private string _brand;
    private string _model;
    private string _licensePlate;


    public string Brand
    {
        get => _brand;
        set => _brand = value;
    }

    public string Model
    {
        get => _model;
        set => _model = value;
    }

    public string LicensePlate
    {
        get => _licensePlate;
        set => _licensePlate = value;
    }

    // Construtor padrão
    public Vehicle()
    {
        _brand = string.Empty;
        _model = string.Empty;
        _licensePlate = string.Empty;
    }

    // Construtor com parâmetros
    public Vehicle(string brand, string model, string licensePlate)
    {
        _brand = brand;
        _model = model;
        _licensePlate = licensePlate;
    }
}
