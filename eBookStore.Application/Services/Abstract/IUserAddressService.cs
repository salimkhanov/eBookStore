using eBookStore.Application.DTOs.UserAddress;

namespace eBookStore.Application.Services.Abstract;

public interface IUserAddressService
{
    Task<List<UserAddressDTO>> GetUserAddressesAsync();
    Task<UserAddressDTO> GetUserAddressByIdAsync();
    Task<bool> CreateUserAddressAsync(UserAddressDTO userAddressDTO);
    Task<bool> UpdateUserAddressAsync(UserAddressDTO userAddressDTO);
    Task<bool> DeleteUserAddressAsync(int id);
}
