using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Address
{
    [Key]
    private int _addressId;
    private string _cep;
    private string _streetName;
    private string _number;

    public string StreetName
    {
        get => _streetName;
        set => _streetName = value;
    }

    public int AddressId
    {
        get => _addressId;
        set => _addressId = value;
    }

    public string Number
    {
        get => _number;
        set => _number = value;
    }

    public string Cep
    {
        get => _cep;
        set => _cep = value;
    }

    public Address()
    {
        _streetName = string.Empty;
        _number = string.Empty;
        _cep = string.Empty;
    }
    public Address(int addressId, string streetName, string number, string cep)
    {
        _addressId = addressId;
        _streetName = streetName;
        _number = number;
        _cep = cep;
    }
}
