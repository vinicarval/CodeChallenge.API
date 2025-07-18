using CodeChallenge.API.Models;

namespace CodeChallenge.API.Repository;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product?> GetProductByIdAsync(int id);
    public Task<Product> AddProductAsync(Product product);
    public Task<Product?> UpdateProductAsync(Product product);
    public Task<bool> DeleteProductAsync(int id);
}

