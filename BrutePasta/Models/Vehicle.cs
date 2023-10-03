using BrutePasta.Models;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

public class Vehicle
{
    [Key]
    public string LicensePlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DeliveryMan? DeliveryMan { get; set; }

    public Vehicle() { }

    // Construtor com parâmetros
    public Vehicle(string brand, string model, string licensePlate, DeliveryMan deliveryMan)
    {
        Brand = brand;
        Model = model;
        LicensePlate = licensePlate;
        DeliveryMan = deliveryMan;
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
