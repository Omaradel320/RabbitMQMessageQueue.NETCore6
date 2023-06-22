namespace RabbitMqProductAPI.Resources.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IRabbitMQProducer _messageSender;
    private readonly IMapper _mapper;
    public GetProductByIdQueryHandler(ApplicationDbContext context, IMapper mapper, IRabbitMQProducer messageSender)
    {
        _context = context;
        _mapper = mapper;
        _messageSender = messageSender;
    }
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(request.Id));
        var response = _mapper.Map<ProductDto>(product);

        _messageSender.SendProductMessage(response);
        return response;
    }
}