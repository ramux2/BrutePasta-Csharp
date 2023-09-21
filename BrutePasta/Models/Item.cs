namespace BrutePasta.Models;

public class Item
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public Product? Product { get; set; }

    public Item() {}
    public Item(int itemId, Product product, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
        Product = product;
    }

    public static float calculateSubtotal(Item item, Product product)
    {
        return product.Price * item.Quantity;
    }
}
