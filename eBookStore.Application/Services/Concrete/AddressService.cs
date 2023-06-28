using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class AddressService:IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    public AddressService(
        IAddressRepository addressRepository,
        ICountryRepository countryRepository,
        IMapper mapper)
    {
        _addressRepository = addressRepository;
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public List<GetAddressDTO> GetAddresses()
    {
        var addresses = _addressRepository.GetAll();
        return _mapper.Map<List<GetAddressDTO>>(addresses);
    }

    public GetAddressDTO GetAddressById(int addressId)
    {
        var address = _addressRepository.GetById(addressId);
        return _mapper.Map<GetAddressDTO>(address);
    }

    public bool CreateAddress(CreateAddressDTO createAddressDTO)
    {
        var countryId = _countryRepository.GetById(createAddressDTO.CountryId);
        if (countryId != null)
        {
            var address = _mapper.Map<Address>(createAddressDTO);
            _addressRepository.Add(address);
            return true;
        }
        return false;
    }

    public bool UpdateAddress(UpdateAddressDTO updateAddressDTO)
    {
        var countryId = _countryRepository.GetById(updateAddressDTO.CountryId);

        if (countryId != null)
        {
            var address = _addressRepository.GetById(updateAddressDTO.Id);
            if (address != null && address.EntityStatus != EntityStatus.Deactive)
            {
                address.UnitNumber = updateAddressDTO.UnitNumber;
                address.StreetNumber = updateAddressDTO.StreetNumber;
                address.FullAddress = updateAddressDTO.FullAddress;
                address.City = updateAddressDTO.City;
                address.Region = updateAddressDTO.Region;
                address.PostalCode = updateAddressDTO.PostalCode;
                address.CountryId = updateAddressDTO.CountryId;
                _addressRepository.Update(address);
                return true;
            }
            return false;
        }
        return false;
    }

    public bool DeleteAddress(int addressId)
    {
        var address = _addressRepository.GetById(addressId);

        if (address != null)
        {
            _addressRepository.Remove(address);
            return true;
        }
        return false;
    }

    public bool DeactivateAddress(int addressId)
    {
        var address = _addressRepository.GetById(addressId);
        if (address != null && address.EntityStatus != EntityStatus.Deactive)
        {
            _addressRepository.Deactivate(address);
            return true;
        }
        return false;
    }

    public bool ActivateAddress(int addressId)
    {
        var address = _addressRepository.GetById(addressId);
        if (address != null && address.EntityStatus != EntityStatus.Active)
        {
            _addressRepository.Activate(address);
            return true;
        }
        return false;
    }

    public List<GetAllAddressDropDown> AllAddressForDropDown()
    {
        List<GetAllAddressDropDown> addresses = null;

        var addressEntities = _addressRepository.GetAll();

        addresses = addressEntities.Where(x => x.EntityStatus == EntityStatus.Active)
            .OrderBy(u => u.Id)
            .Select(x => new GetAllAddressDropDown() { Key = x.Id, Value = x.FullAddress }).ToList();
        return addresses;
    }

    public bool CreateAddresses(List<CreateAddressDTO> createAddressDTOs)
    {
        var countries = _countryRepository.GetAll();
        var addressesToAdd = createAddressDTOs
            .Where(dto => countries.Any(country => country.Id == dto.CountryId))
            .Select(dto => _mapper.Map<Address>(dto))
            .ToList();

        if (addressesToAdd.Count > 0)
        {
            _addressRepository.AddRange(addressesToAdd);
            return true;
        }
        return false;
    }

    public bool DeleteAddresses(List<int> addressesIds)
    {
        var addressesToDelete = _addressRepository.GetAll()
            .Where(x => addressesIds.Contains(x.Id)).ToList();

        if (addressesToDelete != null && addressesToDelete.Count > 0)
        {
            _addressRepository.RemoveRange(addressesToDelete);
            return true;
        }
        return false;
    }

    public bool UpdateAddresses(List<UpdateAddressDTO> updateAddressesDTO)
    {
        List<Address> addressesToUpdate = new List<Address>();

        foreach (var addressDTO in updateAddressesDTO)
        {
            var countryId = _countryRepository.GetById(addressDTO.CountryId);
            if (countryId != null)
            {
                var address = _addressRepository.GetById(addressDTO.Id);
                if (address != null)
                {
                    address.UnitNumber = addressDTO.UnitNumber;
                    address.StreetNumber = addressDTO.StreetNumber;
                    address.FullAddress = addressDTO.FullAddress;
                    address.City = addressDTO.City;
                    address.Region = addressDTO.Region;
                    address.PostalCode = addressDTO.PostalCode;
                    address.CountryId = addressDTO.CountryId;
                    addressesToUpdate.Add(address);
                }
            }
        }
        if (addressesToUpdate.Count > 0)
        {
            _addressRepository.UpdateRange(addressesToUpdate);
            return true;
        }
        return false;
    }
}
