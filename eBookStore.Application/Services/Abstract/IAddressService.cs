using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.UserAddress;

namespace eBookStore.Application.Services.Abstract;

public interface IAddressService
{
    Task<List<AddressResponseDTO>> GetAddressesAsync(); 
    Task<AddressResponseDTO> GetAddressByIdAsync(int addressId);
    Task CreateAddressAsync(AddressRequestDTO addressRequestDTO);
    Task<bool> UpdateAddressAsync(AddressRequestDTO addressRequestDTO);
    Task<bool> DeleteAddressAsync(int addressId);
    Task<bool> MakeAsDefaultAsync(int addressId);
}
