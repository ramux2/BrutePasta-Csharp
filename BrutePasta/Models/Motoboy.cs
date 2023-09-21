namespace BrutePasta.Models;

public class Motoboy
{
    public int MotoboyId { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public float OrderTax { get; set; }
    public Vehicle? Vehicle { get; set; }

    public Motoboy()
    {
        Cpf = string.Empty;
        Name = string.Empty;
    }

    public Motoboy(int motoboyId, string cpf, string name, float orderTax, Vehicle vehicle)
    {
        MotoboyId = motoboyId;
        Cpf = cpf;
        Name = name;
        OrderTax = orderTax;
        Vehicle = vehicle;
    }
}
