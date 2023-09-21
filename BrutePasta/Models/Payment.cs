namespace BrutePasta.Models;
public class Payment
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public float Value { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public Payment() {}

    public Payment(int paymentId, int orderId, float value, PaymentMethod paymentMethod)
    {
        PaymentId = paymentId;
        OrderId = orderId;
        Value = value;
        PaymentMethod = paymentMethod;
    }
}