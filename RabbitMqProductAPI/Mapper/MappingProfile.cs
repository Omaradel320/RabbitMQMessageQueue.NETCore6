using RabbitMqProductAPI.Resources.Products.Commands.Create;
using RabbitMqProductAPI.Resources.Products.Commands.Update;

namespace RabbitMqProductAPI.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<AddProductCommand, Product>().ReverseMap();
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
    }
}