using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.DTOs.BookLanguage;
using eBookStore.Application.DTOs.CartItem;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.DTOs.Discount;
using eBookStore.Application.DTOs.Order;
using eBookStore.Application.DTOs.OrderStatus;
using eBookStore.Application.DTOs.PaymentMethod;
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

        CreateMap<BookUpdateDTO, Book>();
        CreateMap<BookCreateDTO, Book>();

        CreateMap<Address, AddressResponseDTO>();
        CreateMap<AddressRequestDTO, Address>();

        CreateMap<PaymentMethod, PaymentMethodResponseDTO>();
        CreateMap<PaymentMethodRequestDTO, PaymentMethod>();

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
        CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();

        CreateMap<Order, OrderResponseDTO>()
            .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.CardNumber))
            .ForMember(dest => dest.AddressLine, opt => opt.MapFrom(src => src.Address.AddressLine))
            .ForMember(dest => dest.ShippingMethodName, opt => opt.MapFrom(src => src.ShippingMethod.Name))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.Status));


        CreateMap<CartItem, CartItemDTO>().ReverseMap();

        CreateMap<OrderCreateDTO, Order>();
    }
}
