using Microsoft.EntityFrameworkCore;
using RabbitMqProductAPI.Models;

namespace RabbitMqProductAPI.Data;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
    public DbSet<Product> Products { get; set; }
}