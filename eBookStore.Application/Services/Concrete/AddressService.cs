using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.UserAddress;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUserAddressRepository _userAddressRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AddressService(
        IAddressRepository addressRepository,
        IUserAddressRepository userAddressRepository,
        IUserService userService,
        IMapper mapper)
    {
        _addressRepository = addressRepository;
        _userAddressRepository = userAddressRepository;
        _userService = userService;
        _mapper = mapper;
    }
    public async Task CreateAddressAsync(AddressRequestDTO addressRequestDTO)
    {
        var mapped = _mapper.Map<Address>(addressRequestDTO);
        await _addressRepository.AddAsync(mapped);

        var userAddress = new UserAddress
        {
            UserId = await _userService.GetCurrentUserIdAsync(),
            AddressId = addressRequestDTO.Id
        };
        await _userAddressRepository.AddAsync(userAddress);
    }

    public async Task<bool> DeleteAddressAsync(int addressId)
    {
        var currentUserId = await _userService.GetCurrentUserIdAsync();
        var userAddress = (await _userAddressRepository.FindAsync(ua => ua.UserId == currentUserId && ua.AddressId == addressId)).FirstOrDefault();

        if (userAddress == null)
        {
            return false;
        }
        await _userAddressRepository.RemoveAsync(userAddress);
        return true;
    }

    public async Task<AddressResponseDTO> GetAddressByIdAsync(int addressId)
    {
        var currentUserId = await _userService.GetCurrentUserIdAsync();
        var userAddress = (await _userAddressRepository.FindAsync(ua => ua.UserId == currentUserId && ua.AddressId == addressId)).FirstOrDefault();
        
        if (userAddress == null)
        {
            throw new InvalidOperationException("The address does not belong to the current user.");
        }
        var address = await _addressRepository.GetByIdAsync(userAddress.AddressId);
        return _mapper.Map<AddressResponseDTO>(address);
    }

    public async Task<List<AddressResponseDTO>> GetAddressesAsync()
    {
        var currentUserId = await _userService.GetCurrentUserIdAsync();
        var userAddresses = await _userAddressRepository.FindAsync(ua => ua.UserId == currentUserId);
        var addresses = await _addressRepository.FindAsync(ua => userAddresses.Select(ua => ua.AddressId).Contains(ua.Id));
        return _mapper.Map<List<AddressResponseDTO>>(addresses);
    }

    public async Task<bool> MakeAsDefaultAsync(int addressId)
    {
        var userId =await  _userService.GetCurrentUserIdAsync();
        var userAddress = (await _userAddressRepository.FindAsync(ua =>
            ua.AddressId == addressId && ua.UserId == userId)).FirstOrDefault();

        if (userAddress == null)
        {
            return false;
        }

        userAddress.IsDefault = true;
        await _userAddressRepository.UpdateAsync(userAddress);
        return true;

    }

    public async Task<bool> UpdateAddressAsync(AddressRequestDTO addressRequestDTO)
    {
        var userId = await _userService.GetCurrentUserIdAsync();
        var userAddress = (await _userAddressRepository.FindAsync(ua =>
            ua.AddressId == addressRequestDTO.Id && ua.UserId == userId)).FirstOrDefault();
        if (userAddress == null)
        {
            return false;
        }

        var updatedAddress = _mapper.Map<Address>(addressRequestDTO);
        await _addressRepository.AddAsync(updatedAddress);

        //Update UserAddress

        return true;
    }
}
