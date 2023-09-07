namespace BrutePasta.Models;

public class PaymentMethod
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public PaymentMethod()
    {
        _name = string.Empty;
    }
    public PaymentMethod(string name)
    {
        _name = name;
    }
}