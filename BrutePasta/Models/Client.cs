namespace BrutePasta.Models;

public class Client
{
    private string _name;
    private string _cpf;
    private Adress _adress;
    private string _phoneNumber;
    private List<Order> _orders;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public string Cpf
    {
        get => _cpf;
        set => _cpf = value;
    }
    public Adress Adress
    {
        get => _adress;
        set => _adress = value;
    }
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value;
    }

    public List<Order> Orders
    {
        get => _orders;
        set => _orders = value;
    }

    public Client()
    {
        _name = string.Empty;
        _cpf = string.Empty;
        _phoneNumber = string.Empty;
    }
    public Client(string name, string cpf, Adress adress, string phoneNumber)
    {
        _name = name;
        _cpf = cpf;
        _adress = adress;
        _phoneNumber = phoneNumber;
    }
}
