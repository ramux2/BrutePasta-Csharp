using System.ComponentModel.DataAnnotations;


namespace BrutePasta.Models;
public class ProductType
{
    [Key]
    private int _productTypeId;
    private string _name;

    public int ProductTypeId
    {
        get => _productTypeId;
        set => _productTypeId = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public ProductType()
    {
        _name = string.Empty;
    }
    public ProductType(int productTypeId, string name)
    {
        _productTypeId = productTypeId;
        _name = name;
    }
}
