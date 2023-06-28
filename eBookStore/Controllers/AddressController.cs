using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
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
            if (_addressService.CreateAddress(createAddressDTO))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to Create Address");
        }

        [Route("/UpdateAddress")]
        [HttpPut]
        public IActionResult UpdateAddress(UpdateAddressDTO updateAddressDTO)
        {
            if (_addressService.UpdateAddress(updateAddressDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update Address");
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

            if (_addressService.CreateAddresses(createAddressesDTO))
            {
                 return Ok("Successfully created");
            }
            return BadRequest("Failed to created");
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
            if (_addressService.UpdateAddresses(updateAddressesDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update addresses");
        }
    }
}
