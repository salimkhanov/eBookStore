using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Http;
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

        [Route("/GetById")]
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
            try
            {
                _addressService.CreateAddress(createAddressDTO);
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred"+ex.Message);
            }
        }

        [Route("/UpdateAddress")]
        [HttpPut]
        public IActionResult UpdateAddress(UpdateAddressDTO updateAddressDTO)
        {
            if (_addressService.UpdateAddress(updateAddressDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Address with ID {updateAddressDTO.Id} not found.");
        }
    }
}
