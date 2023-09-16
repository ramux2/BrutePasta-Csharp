using System.ComponentModel.DataAnnotations;
namespace BrutePasta.Models;

public class Item
{
    [Key]
    private int _itemId;
    private int _quantity;
    private Product? _product;

    public int ItemId
    {
        get => _itemId;
        set => _itemId = value;
    }

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
    public Item(int itemId, Product product, int quantity)
    {
        _itemId = itemId;
        _product = product;
        _quantity = quantity;
    }

    public static float calculateSubtotal(Item item, Product product)
    {
        return product.Price * item.Quantity;
    }
}
