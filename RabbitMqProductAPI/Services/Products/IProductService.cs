using RabbitMqProductAPI.Dtos;
using RabbitMqProductAPI.Models;

namespace RabbitMqProductAPI.Services.Products;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int Id);
    Task<Product> AddProductAsync(AddProductDto dto);
    Task<Product> UpdateProductAsync(UpdateProductDto dto);
    Task<Product> DeleteProductAsync(int Id);
}