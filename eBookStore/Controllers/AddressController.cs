using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        public AddressController(IAddressService addressService, ICountryService countryService)
        {
            _addressService = addressService;
            _countryService = countryService;
        }

        [Route("/GetAllAddresses")]
        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            return Ok(_addressService.GetAddresses());
        }

        [Route("/GetAddressById")]
        [HttpGet]
        public IActionResult GetAddressById(int addressId)
        {
            var result = _addressService.GetAddressById(addressId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/CreateAddress")]
        [HttpPost]
        public IActionResult CreateAddress(CreateAddressDTO createAddressDTO)
        {
            var country = _countryService.GetCountryById(createAddressDTO.CountryId);
            if (country != null)
            {
                _addressService.CreateAddress(createAddressDTO);
                return Ok("Successfully created");
            }
            return BadRequest($"CountryId with ID {createAddressDTO.CountryId} not found.");
        }

        [Route("/UpdateAddress")]
        [HttpPut]
        public IActionResult UpdateAddress(UpdateAddressDTO updateAddressDTO)
        {
            var countryId = _countryService.GetCountryById(updateAddressDTO.CountryId);

            if (countryId != null)
            {
                if (_addressService.UpdateAddress(updateAddressDTO))
                {
                    return Ok("Successfully updated");
                }
                return BadRequest($"Address with ID {updateAddressDTO.Id} not found.");
            }
            return BadRequest($"CountryId with ID {updateAddressDTO.CountryId} not found.");
        }

        [Route("/DeleteAddress")]
        [HttpDelete]
        public IActionResult DeleteAddress(int addressId)
        {
            if (_addressService.DeleteAddress(addressId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"Address with ID {addressId} not found.");
        }

        [Route("/DeactivateAddress")]
        [HttpPut]
        public IActionResult DeactivateAddress(int addressId)
        {
            if (_addressService.DeactivateAddress(addressId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"Address with ID {addressId} not found.");
        }

        [Route("/ActivateAddress")]
        [HttpPut]
        public IActionResult ActivateAddress(int addressId)
        {
            if (_addressService.ActivateAddress(addressId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"Address with ID {addressId} not found.");
        }

        [Route("/AllAddressesForDropDown")]
        [HttpGet]
        public IActionResult AllAddressesForDropDown()
        {
            return Ok(_addressService.AllAddressForDropDown());
        }

        [Route("/CreateAddresses")]
        [HttpPost]
        public IActionResult CreateAddresses(List<CreateAddressDTO> createAddressesDTO)
        {
            foreach (var createAddressDTO in createAddressesDTO)
            {
                var countryId = _countryService.GetCountryById(createAddressDTO.CountryId);

                if (countryId == null)
                {
                    return BadRequest($"CountryId with ID {createAddressDTO.CountryId} not found.");
                }
            }
            _addressService.CreateAddresses(createAddressesDTO);
            return Ok("Successfully created");
        }

        [Route("/DeleteAddresses")]
        [HttpDelete]
        public IActionResult DeleteAddresses(List<int> addresses)
        {
            if (_addressService.DeleteAddresses(addresses))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/UpdateAddresses")]
        [HttpPut]
        public IActionResult UpdateAddresses(List<UpdateAddressDTO> updateAddressesDTO)
        {
            foreach (var updateAddressDTO in updateAddressesDTO)
            {
                var countryId = _countryService.GetCountryById(updateAddressDTO.CountryId);

                if (countryId == null)
                {
                    return BadRequest($"CountryId with ID {updateAddressDTO.CountryId} not found.");
                }
            }

            if (_addressService.UpdateAddresses(updateAddressesDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update addresses");
        }
    }
}