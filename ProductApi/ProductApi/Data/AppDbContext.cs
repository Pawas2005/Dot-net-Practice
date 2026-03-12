using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 50000, Quantity = 10, Description = "High-performance laptop" },
                new Product { Id = 2, Name = "Mouse", Price = 500, Quantity = 50, Description = "Wireless mouse" },
                new Product { Id = 3, Name = "Keyboard", Price = 1200, Quantity = 30, Description = "Mechanical keyboard" }
            );
        }
    }
}
