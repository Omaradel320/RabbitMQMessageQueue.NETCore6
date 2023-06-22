namespace RabbitMqProductAPI.Resources.Products.Commands.Create;
public class AddProductCommand : IRequest<ProductDto>
{
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public double ProductPrice { get; set; }
    public int ProductStock { get; set; }
}