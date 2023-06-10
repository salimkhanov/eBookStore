using eBookStore.Application.DTOs.Address;

namespace eBookStore.Application.Services.Abstract
{
    public interface IAddressService
    {
        List<GetAddressDTO> GetAddresses();
        GetAddressDTO GetAddressById(int addressId);
        void CreateAddress(CreateAddressDTO createAddressDTO);
        bool UpdateAddress(UpdateAddressDTO updateAddressDTO);
    }
}
