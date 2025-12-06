using AutoMapper;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddAuthorDto, Author>().ReverseMap();
        CreateMap<AddBookDto, Book>().ReverseMap();
        CreateMap<AddOrderDto, Order>().ReverseMap();
        CreateMap<AddOrderBookDto, OrderBook>().ReverseMap();
        
        CreateMap<UpdateAuthorDto, Author>().ReverseMap();
        CreateMap<UpdateBookDto, Book>().ReverseMap();
        CreateMap<UpdateOrderDto, Order>().ReverseMap();
        CreateMap<UpdateOrderBookDto, OrderBook>().ReverseMap();
    }
}
