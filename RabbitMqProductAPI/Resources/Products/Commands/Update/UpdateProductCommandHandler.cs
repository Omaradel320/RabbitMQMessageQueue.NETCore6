namespace RabbitMqProductAPI.Resources.Products.Commands.Update;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IRabbitMQProducer _messageSender;
    public UpdateProductCommandHandler(IMapper mapper, ApplicationDbContext context, IRabbitMQProducer messageSender)
    {
        _mapper = mapper;
        _context = context;
        _messageSender = messageSender;
    }
    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(request.Id), cancellationToken);
        product = _mapper.Map<Product>(request);

        var response = _mapper.Map<ProductDto>(product);

        _messageSender.SendProductMessage(response);
        return response;
    }
}