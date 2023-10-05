namespace BrutePasta.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }

    public PaymentMethod()
    {
        Name = string.Empty;
    }
    public PaymentMethod(int id, string name)
    {
        Id = id;
        Name = name;
    }
}