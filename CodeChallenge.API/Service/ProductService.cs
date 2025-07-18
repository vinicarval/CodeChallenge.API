using CodeChallenge.API.Models;
using CodeChallenge.API.Repository;

namespace CodeChallenge.API.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product> AddProductAsync(Product product)
    {
        return _productRepository.AddProductAsync(product);
    }

    public Task<bool> DeleteProductAsync(int id)
    {
        return _productRepository.DeleteProductAsync(id);
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return _productRepository.GetAllProductsAsync();
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        return _productRepository.GetProductByIdAsync(id);
    }

    public Task<Product?> UpdateProductAsync(Product product)
    {
        return _productRepository.UpdateProductAsync(product);
    }
}

