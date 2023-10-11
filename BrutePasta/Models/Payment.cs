namespace BrutePasta.Models;
public class Payment
{
    public int Id { get; set; }
    public float Value { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}