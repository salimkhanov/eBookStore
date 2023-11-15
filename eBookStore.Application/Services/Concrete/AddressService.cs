using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AddressService(
        IAddressRepository addressRepository,
        IUserService userService,
        IMapper mapper)
    {
        _addressRepository = addressRepository;
        _userService = userService;
        _mapper = mapper;
    }
    public async Task CreateAddressAsync(AddressRequestDTO addressRequestDTO)
    {
        var address = _mapper.Map<Address>(addressRequestDTO);
        address.UserId = await _userService.GetCurrentUserIdAsync();

        // First created address is set as default
        address.IsDefault = true;
        await _addressRepository.AddAsync(address);
    }

    public async Task<bool> DeleteAddressAsync(int addressId)
    {
        var address = await _addressRepository.GetByIdAsync(addressId);
        if (address != null)
        {
            await _addressRepository.RemoveAsync(address);
            return true;
        }
        return false;
    }

    public async Task<AddressResponseDTO> GetAddressByIdAsync(int addressId)
    {
        var address = await _addressRepository.GetByIdAsync(addressId);
        return _mapper.Map<AddressResponseDTO>(address);
    }

    public async Task<List<AddressResponseDTO>> GetAddressesAsync()
    {
        var addresses = await _addressRepository.GetAllAsync();
        return _mapper.Map<List<AddressResponseDTO>>(addresses);
    }

    public async Task<List<AddressResponseDTO>> GetUserAddressesAsync()
    {
        var user = await _userService.GetCurrentUserIdAsync();

        var addresses = await _addressRepository
            .FindAsync(pm => pm.UserId == user);

       return _mapper.Map<List<AddressResponseDTO>>(addresses);
    }

    public async Task<bool> MakeAsDefaultAsync(int addressId)
    {
        var address = await _addressRepository.GetByIdAsync(addressId);
        var user = await _userService.GetCurrentUserIdAsync();

        if(address != null)
        {
            var defaultAddress = (await _addressRepository
                .FindAsync(a => a.IsDefault == true && a.UserId == user))
                .FirstOrDefault();

            if (defaultAddress != null)
            {
                address.IsDefault = true;
                defaultAddress.IsDefault = false;
                await _addressRepository.UpdateAsync(address);
                await _addressRepository.UpdateAsync(defaultAddress);
                return true;
            }
        }
        return false;
    }

    public async Task<bool> UpdateAddressAsync(AddressRequestDTO addressRequestDTO)
    {
        var address = await _addressRepository.GetByIdAsync(addressRequestDTO.Id);
        if (address != null)
        {
            _mapper.Map(addressRequestDTO, address);
            await _addressRepository.UpdateAsync(address);
            return true;
        }
        return false;
    }
}
