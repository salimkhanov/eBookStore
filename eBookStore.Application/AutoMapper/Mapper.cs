using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.ShoppingCartItem;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.DTOs.UserPaymentMethod;
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

        #region Country

        CreateMap<Country, GetCountryDTO>();
        CreateMap<CreateCountryDTO, Country>();
        CreateMap<UpdateCountryDTO, Country>();

        #endregion

        #region ShoppingCart

        CreateMap<ShoppingCart, GetShoppingCartDTO>();
        CreateMap<CreateShoppingCartDTO, ShoppingCart>();
        CreateMap<UpdateShoppingCartDTO,ShoppingCart>();

        #endregion

        #region ShoppingCartItem

        CreateMap<ShoppingCartItem, GetShoppingCartItemDTO>();
        CreateMap<CreateShoppingCartItemDTO, ShoppingCartItem>();
        CreateMap<UpdateShoppingCartItemDTO,ShoppingCartItem>();

        #endregion

        #region PaymentType

        CreateMap<PaymentType,GetPaymentTypeDTO>();
        CreateMap<CreatePaymentTypeDTO, PaymentType>();
        CreateMap<UpdatePaymentTypeDTO, PaymentType>();

        #endregion

        #region UserPaymentMethod

        CreateMap<UserPaymentMethod, GetUserPaymentMethodDTO>();
        CreateMap<CreateUserPaymentMethodDTO, UserPaymentMethod>();
        CreateMap<UpdateUserPaymentMethodDTO,UserPaymentMethod>();

        #endregion
    }
}
