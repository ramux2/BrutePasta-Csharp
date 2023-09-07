using System.ComponentModel.DataAnnotations;


namespace BrutePasta.Models;
public class ProductType
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public ProductType()
    {
        _name = string.Empty;
    }
    public ProductType(string name)
    {
        _name = name;
    }
}
