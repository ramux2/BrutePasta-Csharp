namespace BrutePasta.Models;
public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ProductType()
    {
        Name = string.Empty;
    }
    public ProductType(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
