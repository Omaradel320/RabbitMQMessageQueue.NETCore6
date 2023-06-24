namespace RabbitMqProductAPI.Resources.Products.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly ApplicationDbContext _DbContext;
    private readonly IMapper _mapper;
    private readonly IRabbitMQProducer _messageSender;
    public GetAllProductsQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IRabbitMQProducer messageSender)
    {
        _DbContext = dbContext;
        _mapper = mapper;
        _messageSender = messageSender;
    }
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _DbContext.Products.Where(p => !p.IsDeleted).ToListAsync();
        var response = _mapper.Map<IEnumerable<ProductDto>>(productList);

        _messageSender.SendProductMessage(response);
        return response;
    }
}