using CodeChallenge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.API.Repository;
public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;
    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        var existingProduct = await _context.Products.FindAsync(product.Id);
        if (existingProduct == null)
        {
            return null;
        }
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        _context.Products.Update(existingProduct);
        await _context.SaveChangesAsync();
        return existingProduct;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        _context.Products.Remove(existingProduct);
        await _context.SaveChangesAsync();

        return true;
    }
}

