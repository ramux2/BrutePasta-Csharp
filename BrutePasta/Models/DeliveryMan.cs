using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class DeliveryMan
{
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public float OrderTax { get; set; }

    public DeliveryMan()
    {
        Cpf = string.Empty;
        Name = string.Empty;
    }

    public DeliveryMan(string cpf, string name, float orderTax)
    {
        Cpf = cpf;
        Name = name;
        OrderTax = orderTax;
    }
}
