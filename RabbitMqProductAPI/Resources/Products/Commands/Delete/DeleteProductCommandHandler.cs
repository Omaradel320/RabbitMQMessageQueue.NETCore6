using System.Threading;

namespace RabbitMqProductAPI.Resources.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IRabbitMQProducer _messageSender;
    public DeleteProductCommandHandler(ApplicationDbContext context, IMapper mapper, IRabbitMQProducer messageSender)
    {
        _context = context;
        _mapper = mapper;
        _messageSender = messageSender;
    }

    public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(request.Id), cancellationToken);
        product.IsDeleted = !product.IsDeleted;

        var response = _mapper.Map<ProductDto>(product);
        _messageSender.SendProductMessage(response);

        return response;
    }
}