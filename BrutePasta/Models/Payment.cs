using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;
public class Payment
{
    [Key]
    private int _paymentId;
    private int _orderId;
    private float _value;
    private PaymentMethod _paymentMethod;

    public int PaymentId
    {
        get => _paymentId;
        set => _paymentId = value;
    }

    public int OrderId
    {
        get => _orderId;
        set => _orderId = value;
    }

    public float Value
    {
        get => _value;
        set => _value = value;
    }

    public PaymentMethod PaymentMethod
    {
        get => _paymentMethod;
        set => _paymentMethod = value;
    }

    public Payment()
    {
        _paymentMethod = null;
    }

    public Payment(int paymentId, int orderId, float value, PaymentMethod paymentMethod)
    {
        _paymentId = paymentId;
        _orderId = orderId;
        _value = value;
        _paymentMethod = paymentMethod;
    }
}