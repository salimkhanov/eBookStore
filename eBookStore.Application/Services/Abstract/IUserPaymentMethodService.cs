using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.UserPaymentMethod;

namespace eBookStore.Application.Services.Abstract;

public interface IUserPaymentMethodService
{
    List<GetUserPaymentMethodDTO> GetUserPaymentMethods();
    GetUserPaymentMethodDTO GetUserPaymentMethodById(int userPaymentMethodId);
    Task<bool> CreateUserPaymentMethod(CreateUserPaymentMethodDTO createUserPaymentMethodDTO);
    Task<bool> UpdateUserPaymentMethod(UpdateUserPaymentMethodDTO updateUserPaymentMethod);
    bool DeleteUserPaymentMethod(int userPaymentMethodId);
    bool DeactivateUserPaymentMethod(int userPaymentMethodId);
    bool ActivateUserPaymentMethod(int userPaymentMethodId);
    bool CreateUserPaymentMethods(List<CreateUserPaymentMethodDTO> createUserPaymentMethodDTOs);
    bool DeleteUserPaymentMethods(List<int> userPaymentMethods);
    Task<bool> UpdateUserPaymentMethods(List<UpdateUserPaymentMethodDTO> updateUserPaymentMethods);
}
