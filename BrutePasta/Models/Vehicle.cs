using System.Text.RegularExpressions;

public class Vehicle
{
   public int VehicleId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }

    // Construtor com parâmetros
    public Vehicle(int vehicleId, string brand, string model, string licensePlate)
    {
        VehicleId = vehicleId;
        Brand = brand;
        Model = model;
        LicensePlate = licensePlate;
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
