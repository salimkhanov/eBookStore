using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.RoleDTO;
using eBookStore.Domain.Entities;

namespace eBookStore.Application.Services.Abstract
{
    public interface IAddressService
    {
        List<GetAddressDTO> GetAddresses();
        GetAddressDTO GetAddressById(int addressId);
        void CreateAddress(CreateAddressDTO createAddressDTO);
        bool UpdateAddress(UpdateAddressDTO updateAddressDTO);
        bool DeleteAddress(int addressId);
        bool DeactivateAddress(int addressId);
        bool ActivateAddress(int addressId);
        List<GetAllAddressDropDown> AllAddressForDropDown();
        void CreateAddresses(List<CreateAddressDTO> createAddressDTOs);
        bool DeleteAddresses(List<int> addresses);
        bool UpdateAddresses(List<UpdateAddressDTO> updateAddressesDTO);
    }
}
