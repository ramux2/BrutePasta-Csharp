namespace BrutePasta.Models;
public class RestaurantOrder
{
    public int Id { get; set; }
    public List<Item> Items { get; set; }
    public Client Client { get; set; }
    public DeliveryMan DeliveryMan { get; set; }
    public DateTime PaymentDate { get; set; }
    public Payment Payment { get; set; }

    public RestaurantOrder() {}

    public RestaurantOrder(int id, Client client, List<Item> items, DeliveryMan deliveryMan, DateTime paymentDate, Payment payment)
    {
        Id = id;
        Client = client;
        Items = items;
        PaymentDate = paymentDate;
        DeliveryMan = deliveryMan;
        Payment = payment;
    }
}