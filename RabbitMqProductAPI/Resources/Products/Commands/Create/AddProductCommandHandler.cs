namespace RabbitMqProductAPI.Resources.Products.Commands.Create;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IRabbitMQProducer _messageSender;
    public AddProductCommandHandler(IMapper mapper, ApplicationDbContext context, IRabbitMQProducer messageSender)
    {
        _mapper = mapper;
        _context = context;
        _messageSender = messageSender;
    }

    public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellatioToken)
    {
        var newProduct = _mapper.Map<Product>(request);
        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<ProductDto>(newProduct);

        _messageSender.SendProductMessage(response);
        return response;
    }
}