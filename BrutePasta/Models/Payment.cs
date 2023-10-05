namespace BrutePasta.Models;
public class Payment
{
    public int Id { get; set; }
    public float Value { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public Payment() {}

    public Payment(int id, float value, PaymentMethod paymentMethod)
    {
        Id = id;
        Value = value;
        PaymentMethod = paymentMethod;
    }
}