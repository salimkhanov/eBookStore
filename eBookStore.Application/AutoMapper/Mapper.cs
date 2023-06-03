using AutoMapper;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities.Authorizations;

namespace IdentityTask.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<RegistrationDTO, User>();
    }
}
