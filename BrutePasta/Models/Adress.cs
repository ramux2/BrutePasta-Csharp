using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Adress
{
    [Key]
    private string _cep;
    private string _streetName;
    private string _number;

    public string StreetName
    {
        get => _streetName;
        set => _streetName = value;
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

    public Adress()
    {
        _streetName = string.Empty;
        _number = string.Empty;
        _cep = string.Empty;
    }
    public Adress(string streetName, string number, string cep)
    {
        _streetName = streetName;
        _number = number;
        _cep = cep;
    }
}
