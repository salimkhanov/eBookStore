using AutoMapper;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.DTOs.BookLanguage;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.DTOs.Discount;
using eBookStore.Application.DTOs.Publisher;
using eBookStore.Application.DTOs.Role;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;
using System.Runtime.InteropServices;

namespace eBookStore.Application.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {

        CreateMap<Book, BookResponseDTO>()
            .ForMember(dest => dest.BookGenreName, opt => opt.MapFrom(src => src.BookGenre.Name))
            .ForMember(dest => dest.BookLanguageName, opt => opt.MapFrom(src => src.BookLanguage.Name))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
            .ForMember(dest => dest.DiscountName, opt => opt.MapFrom(src => src.Discount.Name));

        CreateMap<BookRequestDTO, Book>();

        CreateMap<User, UserResponseDTO>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<RegistrationDTO, User>();

        CreateMap<RoleDTO, Role>().ReverseMap();
        CreateMap<CountryDTO, Country>().ReverseMap();
        CreateMap<AuthorDTO, Author>().ReverseMap();
        CreateMap<PublisherDTO, Publisher>().ReverseMap();
        CreateMap<BookGenreDTO, BookGenre>().ReverseMap();
        CreateMap<BookLanguageDTO, BookLanguage>().ReverseMap();
        CreateMap<DiscountDTO, Discount>().ReverseMap();



    }
}
