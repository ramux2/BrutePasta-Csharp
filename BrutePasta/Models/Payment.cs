using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;
public class Payment
{
    private int _orderId;
    private float _value;
    private DateTime _paymentDate;
    private PaymentMethod _paymentMethod;

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

    public DateTime PaymentDate
    {
        get => _paymentDate;
        set => _paymentDate = value;
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

    public Payment(int orderId, float value, DateTime paymentDate, PaymentMethod paymentMethod)
    {
        _orderId = orderId;
        _value = value;
        _paymentDate = paymentDate;
        _paymentMethod = paymentMethod;
    }
}