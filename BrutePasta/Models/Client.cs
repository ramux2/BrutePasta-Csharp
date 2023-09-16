using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Client
{
    [Key]
    private int _clientId;
    private string _cpf;
    private string _name;
    private Address _address;
    private string _phoneNumber;

    public int ClientId
    {
        get => _clientId; 
        set => _clientId = value;
    }

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
    public Address Adress
    {
        get => _address;
        set => _address = value;
    }
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value;
    }

    public Client()
    {
        _name = string.Empty;
        _cpf = string.Empty;
        _phoneNumber = string.Empty;
    }
    public Client(int clientId, string name, string cpf, Address address, string phoneNumber)
    {
        _clientId = clientId;
        _name = name;
        _cpf = cpf;
        _address = address;
        _phoneNumber = phoneNumber;
    }

    private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
}
