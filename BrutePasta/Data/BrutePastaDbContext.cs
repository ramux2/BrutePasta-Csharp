using BrutePasta.Models;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Data;
public class BrutePastaDbContext : DbContext
{
    DbSet<Client> Client
    {
        get => Client;
        set => Client = value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySQL()
    }
}