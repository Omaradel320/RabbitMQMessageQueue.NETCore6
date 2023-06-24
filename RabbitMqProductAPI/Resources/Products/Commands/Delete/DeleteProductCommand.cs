namespace RabbitMqProductAPI.Resources.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<ProductDto>
{
    public int Id { get; set; }
}
