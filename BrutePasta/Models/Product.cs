namespace BrutePasta.Models;

public class Product
{
    private string _name;
    private int _qtyAvailable;
    private float _price;
    private string _description;

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

    public Product()
    {
        _name = string.Empty;
        _description = string.Empty;
    }
    public Product(string name, int qtyAvailable, float price)
    {
        _name = name;
        _qtyAvailable = qtyAvailable;
        _price = price;
    }
}
