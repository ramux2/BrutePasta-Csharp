namespace BrutePasta.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int QtyAvailable { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public ProductType ProductType { get; set; }

    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
    }
    public Product(int id, string name, int qtyAvailable, float price, string description, ProductType productType)
    {
        Id = id;
        Name = name;
        QtyAvailable = qtyAvailable;
        Price = price;
        Description = description;
        ProductType = productType;
    }
}
