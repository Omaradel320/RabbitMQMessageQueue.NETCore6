namespace RabbitMqProductAPI.Resources.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}