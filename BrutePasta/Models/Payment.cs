namespace BrutePasta.Models;
public class Payment
{
    public int PaymentId { get; set; }
    public float Value { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public Payment() {}

    public Payment(int paymentId, float value, PaymentMethod paymentMethod)
    {
        PaymentId = paymentId;
        Value = value;
        PaymentMethod = paymentMethod;
    }
}