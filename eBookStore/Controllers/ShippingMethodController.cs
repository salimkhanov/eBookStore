using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShippingMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingMethodController : ControllerBase
    {
        private readonly IShippingMethodService _shippingMethodService;

        public ShippingMethodController(IShippingMethodService shippingMethodService)
        {
            _shippingMethodService = shippingMethodService;
        }

        [Route("/ActivateShippingMethod")]
        [HttpPut]
        public IActionResult ActivateShippingMethod(int shippingMethodId)
        {
            if (_shippingMethodService.ActivateShippingMethod(shippingMethodId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"ShippingMethod with ID {shippingMethodId} not found.");
        }

        [Route("/CreateShippingMethod")]
        [HttpPost]
        public IActionResult CreateShippingMethod(CreateShippingMethodDTO createShippingMethodDTO)
        {
            _shippingMethodService.CreateShippingMethod(createShippingMethodDTO);
            return Ok("Successfully created");
        }

        [Route("/CreateShippingMethods")]
        [HttpPost]
        public IActionResult CreateShippingMethods(List<CreateShippingMethodDTO> createShippingMethodDTOs)
        {
            _shippingMethodService.CreateShippingMethods(createShippingMethodDTOs);
            return Ok("Successfully created");
        }

        [Route("/DeactivateShippingMethod")]
        [HttpPut]
        public IActionResult DeactivateShippingMethod(int shippingMethodId)
        {
            if (_shippingMethodService.DeactivateShippingMethod(shippingMethodId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"ShippingMethod with ID {shippingMethodId} not found.");
        }

        [Route("/DeleteShippingMethod")]
        [HttpDelete]
        public IActionResult DeleteShippingMethod(int shippingMethodId)
        {
            if (_shippingMethodService.DeleteShippingMethod(shippingMethodId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"ShippingMethod with ID {shippingMethodId} not found.");
        }

        [Route("/DeleteShippingMethods")]
        [HttpDelete]
        public IActionResult DeleteShippingMethods(List<int> shippingMethods)
        {
            if (_shippingMethodService.DeleteShippingMethods(shippingMethods))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/GetShippingMethodById")]
        [HttpGet]
        public IActionResult GetShippingMethodById(int shippingMethodId)
        {
            var result = _shippingMethodService.GetShippingMethodById(shippingMethodId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/GetAllShippingMethods")]
        [HttpGet]
        public IActionResult GetAllShippingMethods()
        {
            return Ok(_shippingMethodService.GetShippingMethods());
        }

        [Route("/UpdateShippingMethod")]
        [HttpPut]
        public IActionResult UpdateShippingMethod(UpdateShippingMethodDTO updateShippingMethodDTO)
        {
            if (_shippingMethodService.UpdateShippingMethod(updateShippingMethodDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update ShippingMethod");
        }

        [Route("/UpdateShippingMethods")]
        [HttpPut]
        public IActionResult ShippingMethods(List<UpdateShippingMethodDTO> updateShippingMethodDTOs)
        {
            if (_shippingMethodService.UpdateShippingMethods(updateShippingMethodDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update ShippingMethod");
        }
    }
}
