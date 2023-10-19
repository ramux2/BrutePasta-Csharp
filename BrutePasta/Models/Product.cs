using System.Text.Json.Serialization;

namespace BrutePasta.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int QtyAvailable { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public int ProductId { get; set; }
    public ProductType ProductType { get; set; }
}
