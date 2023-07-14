using AutoMapper;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.DTOs.Role;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;
using System.Runtime.InteropServices;

namespace eBookStore.Application.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Book, BookResponseDTO>();

        CreateMap<User, UserResponseDTO>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<RegistrationDTO, User>();

        CreateMap<RoleDTO, Role>().ReverseMap();

        

    }
}
