using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabbitMqProductAPI.Data;
using RabbitMqProductAPI.Dtos;
using RabbitMqProductAPI.Models;

namespace RabbitMqProductAPI.Services.Products;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _DbContext;
    private readonly IMapper _mapper;

    public ProductService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _DbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var productsList = await _DbContext.Products.ToListAsync();

        return productsList;
    }
    public async Task<Product> GetProductByIdAsync(int Id)
    {
        var product = await _DbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(Id));
        return product;
    }
    public async Task<Product> AddProductAsync(AddProductDto dto)
    {
        var newProduct = _mapper.Map<Product>(dto);
        
        await _DbContext.AddAsync(newProduct);
        await _DbContext.SaveChangesAsync();
        return newProduct;
    }
    public async Task<Product> DeleteProductAsync(int Id)
    {
        var product = await _DbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(Id));
        product.IsDeleted = !product.IsDeleted;

        await _DbContext.SaveChangesAsync();
        return product;
    }
    public async Task<Product> UpdateProductAsync(UpdateProductDto dto)
    {
        var product = await _DbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(dto.Id));
        product = _mapper.Map<Product>(dto);

        await _DbContext.SaveChangesAsync();
        return product;
    }
}