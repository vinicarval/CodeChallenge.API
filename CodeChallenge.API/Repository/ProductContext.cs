using CodeChallenge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.API.Repository;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}
