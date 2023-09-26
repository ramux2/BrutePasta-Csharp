using BrutePasta.Models;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Data;
public class BrutePastaDbContext : DbContext
{
    public BrutePastaDbContext(DbContextOptions<BrutePastaDbContext> options) : base(options) {}

    public DbSet<Address> Address { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Motoboy> Motoboy { get; set; }
    public DbSet<Vehicle> Vehicle {  get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductType> ProductType { get; set; }
    public DbSet<RestaurantOrder> RestaurantOrder { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<PaymentMethod> PaymentMethod { get; set; }

}