using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;

namespace IdentityTask.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        #region Registration
        CreateMap<RegistrationDTO, User>();
        #endregion

        #region Address
        CreateMap<Address, GetAddressDTO>();
        CreateMap<CreateAddressDTO,Address>();
        CreateMap<UpdateAddressDTO, Address>();
        #endregion
    }
}
