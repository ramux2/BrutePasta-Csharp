namespace BrutePasta.Models;

public class Address
{
    public int AddressId { get; set; }
    public string Cep { get; set; }
    public string StreetName { get; set; }
    public string Number { get; set; }

    public Address()
    {
        Cep = string.Empty;
        StreetName = string.Empty;
        Number = string.Empty;
    }
    public Address(int addressId, string streetName, string number, string cep)
    {
        AddressId = addressId;
        StreetName = streetName;
        Number = number;
        Cep = cep;
    }
}
