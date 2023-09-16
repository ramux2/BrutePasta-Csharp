using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class PaymentMethod
{
    [Key]
    private int _paymentMethodId;
    private string _name;

    public int PaymentMethodId
    {
        get => _paymentMethodId;
        set => _paymentMethodId = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public PaymentMethod()
    {
        _name = string.Empty;
    }
    public PaymentMethod(int paymentMethodId, string name)
    {
        _paymentMethodId = paymentMethodId;
        _name = name;
    }
}