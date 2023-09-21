namespace BrutePasta.Models;
public class Order
{
    public int OrderId { get; set; }
    public List<Item> Items { get; set; }
    public Client Client { get; set; }
    public Motoboy Motoboy { get; set; }
    public DateTime PaymentDate { get; set; }
    public float TotalValue { get; set; }

    public Order() {}

    public Order(int orderId, Client client, List<Item> items, Motoboy motoboy, DateTime paymentDate, float totalValue)
    {
        OrderId = orderId;
        Client = client;
        Items = items;
        PaymentDate = paymentDate;
        Motoboy = motoboy;
        TotalValue = totalValue;
    }

    public static float calculateSubtotal(Item item)
    {
        return item.Product.Price * item.Quantity;
    }

    public static float calculaTotal(List<Item> items)
    {
        float total = 0;
        foreach (Item item in items)
        {
            total += calculateSubtotal(item);
        }
        total += 20;
        return total;
    }
}