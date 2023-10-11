using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class DeliveryMan
{
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public float OrderTax { get; set; }
}
