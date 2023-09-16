using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class Vehicle
{
    [Key]
    private int _vehicleId;
    private string _brand;
    private string _model;
    private string _licensePlate;

    public int VehicleId
    {
        get => _vehicleId;
        set => _vehicleId = value;
    }

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

    public static bool PlateValidation(string licensePlate)
    {
        // Expressão regular para validar a placa
        string pattern = "^[A-Z]{3}[0-9]{4}$";

        // Cria um objeto Regex com o padrão
        Regex regex = new Regex(pattern);

        // Verifica se a placa corresponde ao padrão
        return regex.IsMatch(licensePlate);
    }
}
