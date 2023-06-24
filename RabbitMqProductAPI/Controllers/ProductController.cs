using RabbitMqProductAPI.Resources.Products.Commands.Create;
using RabbitMqProductAPI.Resources.Products.Commands.Delete;
using RabbitMqProductAPI.Resources.Products.Commands.Update;

namespace RabbitMqProductAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var productList = await _mediator.Send(new GetAllProductsQuery());
        return Ok(productList);
    }

    [HttpGet("GetProductById")]
    public async Task<ProductDto> GetProductById(int Id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery { Id = Id });
        return product;
    }

    [HttpPost("AddNewProduct")]
    public async Task<ProductDto> AddNewProduct(AddProductCommand dto)
    {
        var product = await _mediator.Send(dto);
        return product;
    }

    [HttpPost("UpdateProduct")]
    public async Task<ProductDto> UpdateProduct(UpdateProductCommand dto)
    {
        var updatedProduct = await _mediator.Send(dto);
        return new ProductDto();
    }

    [HttpPost("DeleteProduct")]
    public async Task<ProductDto> DeleteProduct(int Id)
    {
        var deletedProduct = await _mediator.Send(new DeleteProductCommand { Id = Id });
        return deletedProduct;
    }
}