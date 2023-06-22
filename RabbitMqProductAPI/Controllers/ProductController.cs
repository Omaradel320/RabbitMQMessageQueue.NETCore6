using Microsoft.AspNetCore.Mvc;
using RabbitMqProductAPI.Dtos;
using RabbitMqProductAPI.Models;
using RabbitMqProductAPI.RabbitMQ;
using RabbitMqProductAPI.Services.Products;

namespace RabbitMqProductAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IRabbitMQProducer _rabbitMqProducer;
    private readonly IProductService _productService;
    public ProductController(IRabbitMQProducer rabbitMqProducer, IProductService productService)
    {
        _rabbitMqProducer = rabbitMqProducer;
        _productService = productService;
    }

    [HttpGet("GetAllProducts")]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var productList = await _productService.GetAllProductsAsync();

        _rabbitMqProducer.SendProductMessage(productList);

        return productList;
    }
    [HttpGet("GetProductById")]
    public async Task<Product> GetProductById(int Id)
    {
        var product = await _productService.GetProductByIdAsync(Id);

        _rabbitMqProducer.SendProductMessage(product);

        return product;
    }
    [HttpPost("AddNewProduct")]
    public async Task<Product> AddNewProduct(AddProductDto dto)
    {
        var product = await _productService.AddProductAsync(dto);

        _rabbitMqProducer.SendProductMessage(product);

        return product;
    }
    [HttpPost("UpdateProduct")]
    public async Task<Product> UpdateProduct(UpdateProductDto dto)
    {
        var updateProduct = await _productService.UpdateProductAsync(dto);

        _rabbitMqProducer.SendProductMessage(updateProduct);

        return updateProduct;
    }
    [HttpPost("DeleteProduct")]
    public async Task<Product> UpdateProduct(int Id)
    {
        var deletedProduct = await _productService.DeleteProductAsync(Id);

        _rabbitMqProducer.SendProductMessage(deletedProduct);

        return deletedProduct;
    }
}