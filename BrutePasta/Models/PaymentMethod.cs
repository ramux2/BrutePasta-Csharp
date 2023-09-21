namespace BrutePasta.Models;

public class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string Name { get; set; }

    public PaymentMethod()
    {
        Name = string.Empty;
    }
    public PaymentMethod(int paymentMethodId, string name)
    {
        PaymentMethodId = paymentMethodId;
        Name = name;
    }
}