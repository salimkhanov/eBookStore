using AutoMapper;
using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete
{
    public class AddressService:IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            _addressRepository = addressRepository;
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

        public void CreateAddress(CreateAddressDTO createAddressDTO)
        {
            var address = _mapper.Map<Address>(createAddressDTO);
            _addressRepository.Add(address);
        }

        public bool UpdateAddress(UpdateAddressDTO updateAddressDTO)
        {
            var category = _addressRepository.GetById(updateAddressDTO.Id);
            if (category != null && category.EntityStatus != EntityStatus.Deactive)
            {
                var mapped = _mapper.Map<Address>(updateAddressDTO);
                _addressRepository.Update(mapped);
                return true;
            }
            return false;
        }
    }
}
