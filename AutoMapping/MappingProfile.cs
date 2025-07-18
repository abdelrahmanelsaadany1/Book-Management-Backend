using AutoMapper;
using Book_Management_Backend.Dtos;
using Book_Management_Backend.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookDto, Book>().ReverseMap();
     
    }
}
