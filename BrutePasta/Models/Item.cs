namespace BrutePasta.Models;

public class Item
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public Product? Product { get; set; }

    public Item() {}
    public Item(int id, Product product, int quantity)
    {
        Id = id;
        Quantity = quantity;
        Product = product;
    }

    public static float calculateSubtotal(Item item, Product product)
    {
        return product.Price * item.Quantity;
    }
}
