using AutoMapper;
using RabbitMqProductAPI.Dtos;
using RabbitMqProductAPI.Models;

namespace RabbitMqProductAPI.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddProductDto,Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
    }
}