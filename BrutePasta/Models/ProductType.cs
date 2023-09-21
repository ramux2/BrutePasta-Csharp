namespace BrutePasta.Models;
public class ProductType
{
    public int ProductTypeId { get; set; }

    public string Name { get; set; }

    public ProductType()
    {
        Name = string.Empty;
    }
    public ProductType(int productTypeId, string name)
    {
        ProductTypeId = productTypeId;
        Name = name;
    }
}
