using System.ComponentModel.DataAnnotations;
namespace BrutePasta.Models;

public class Item
{
    private Product? _product;
    private int _quantity;


    public Product Product
    {
        get => _product;
        set => _product = value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public Item()
    {
        _product = null;
    }
    public Item(Product product, int quantity)
    {
        _product = product;
        _quantity = quantity;
    }
}
