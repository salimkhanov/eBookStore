using AutoMapper;
using eBookStore.Domain.Entities;
using IdentityTask.DTOs.Authentication;

namespace IdentityTask.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<RegistrationDTO, User>();
    }
}