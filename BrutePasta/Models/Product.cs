using System.ComponentModel.DataAnnotations;

namespace BrutePasta.Models;

public class Product
{
    [Key]
    private int _productId;
    private string _name;
    private int _qtyAvailable;
    private float _price;
    private string _description;
    private ProductType _productType;

    public int ProductId
    {
        get => _productId;
        set => _productId = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public int QtyAvailable
    {
        get => _qtyAvailable;
        set => _qtyAvailable = value;
    }
    public float Price
    {
        get => _price;
        set => _price = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public ProductType ProductType
    {
        get => _productType;
        set => _productType = value;
    }

    public Product()
    {
        _name = string.Empty;
        _description = string.Empty;
    }
    public Product(int productId, string name, int qtyAvailable, float price)
    {
        _productId = productId;
        _name = name;
        _qtyAvailable = qtyAvailable;
        _price = price;
    }
}
