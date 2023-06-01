using AutoMapper;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;

namespace IdentityTask.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<RegistrationDTO, User>();
    }
}
