using System.Text.Json.Serialization;

namespace BrutePasta.Models;

public class Item
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    [JsonIgnore]
    public Product? Product { get; set; }

    public static float calculateSubtotal(Item item, Product product)
    {
        return product.Price * item.Quantity;
    }
}
