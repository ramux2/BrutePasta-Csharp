using System.Text.Json.Serialization;

namespace BrutePasta.Models;

public class Address
{
    public int Id { get; set; }
    public string Cep { get; set; }
    public string StreetName { get; set; }
    public string Number { get; set; }
    public int ClientId { get; set; } //Foreign Key
    [JsonIgnore]
    public Client? Client { get; set; } //Prop de navegação
}
