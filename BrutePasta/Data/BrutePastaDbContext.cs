using BrutePasta.Models;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Data;
public class BrutePastaDbContext : DbContext
{
    public DbSet<Client>? Client
    {
        get => Client;
        set => Client = value;
    }

    public DbSet<Vehicle>? Vehicle
    {
        get => Vehicle;
        set => Vehicle = value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Server=localhost; User Id=root; Password=1234; Database=treinaweb";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
  
        }
    }
}