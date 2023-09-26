namespace BrutePasta.Models;
public class RestaurantOrder
{
    public int RestaurantOrderId { get; set; }
    public List<Item> Items { get; set; }
    public Client Client { get; set; }
    public Motoboy Motoboy { get; set; }
    public DateTime PaymentDate { get; set; }
    public Payment Payment { get; set; }

    public RestaurantOrder() {}

    public RestaurantOrder(int orderId, Client client, List<Item> items, Motoboy motoboy, DateTime paymentDate, Payment payment)
    {
        RestaurantOrderId = orderId;
        Client = client;
        Items = items;
        PaymentDate = paymentDate;
        Motoboy = motoboy;
        Payment = payment;
    }
}