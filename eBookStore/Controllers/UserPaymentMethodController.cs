using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.UserPaymentMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentMethodController : ControllerBase
    {
        private readonly IUserPaymentMethodService _userPaymentMethodService;

        public UserPaymentMethodController(IUserPaymentMethodService userPaymentMethodService)
        {
            _userPaymentMethodService = userPaymentMethodService;
        }

        [Route("/ActivateUserPaymentMethod")]
        [HttpPut]
        public IActionResult ActivateUserPaymentMethod(int userPaymentMethodId)
        {
            if (_userPaymentMethodService.ActivateUserPaymentMethod(userPaymentMethodId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"ShoppingCart with ID {userPaymentMethodId} not found.");
        }

        [Route("/CreateUserPaymentMethod")]
        [HttpPost]
        public async Task<IActionResult> CreateUserPaymentMethod(CreateUserPaymentMethodDTO createUserPaymentMethodDTO)
        {
            if (await _userPaymentMethodService.CreateUserPaymentMethod(createUserPaymentMethodDTO))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to Create UserPaymentMethod");
        }

        [Route("/CreateUserPaymentMethods")]
        [HttpPost]
        public IActionResult CreateUserPaymentMethods(List<CreateUserPaymentMethodDTO> createUserPaymentMethodDTOs)
        {

            if (_userPaymentMethodService.CreateUserPaymentMethods(createUserPaymentMethodDTOs))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to created");
        }

        [Route("/DeactivateUserPaymentMethod")]
        [HttpPut]
        public IActionResult DeactivateUserPaymentMethod(int userPaymentMethodId)
        {
            if (_userPaymentMethodService.DeactivateUserPaymentMethod(userPaymentMethodId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"UserPaymentMethod with ID {userPaymentMethodId} not found.");
        }

        [Route("/DeleteUserPaymentMethod")]
        [HttpDelete]
        public IActionResult DeleteUserPaymentMethod(int userPaymentMethodId)
        {
            if (_userPaymentMethodService.DeleteUserPaymentMethod(userPaymentMethodId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"UserPaymentMethod with ID {userPaymentMethodId} not found.");
        }

        [Route("/DeleteUserPaymentMethods")]
        [HttpDelete]
        public IActionResult DeleteUserPaymentMethods(List<int> userPaymentMethods)
        {
            if (_userPaymentMethodService.DeleteUserPaymentMethods(userPaymentMethods))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }


        [Route("/GetUserPaymentMethodById")]
        [HttpGet]
        public IActionResult GetUserPaymentMethodById(int userPaymentMethodId)
        {
            var result = _userPaymentMethodService.GetUserPaymentMethodById(userPaymentMethodId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/GetAllUserPaymentMethods")]
        [HttpGet]
        public IActionResult GetAllUserPaymentMethods()
        {
            return Ok(_userPaymentMethodService.GetUserPaymentMethods());
        }

        [Route("/UpdateUserPaymentMethod")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserPaymentMethod(UpdateUserPaymentMethodDTO updateUserPaymentMethodDTO)
        {
            if (await _userPaymentMethodService.UpdateUserPaymentMethod(updateUserPaymentMethodDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update UserPaymentMethod");
        }

        [Route("/UpdateUserPaymentMethods")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserPaymentMethods(List<UpdateUserPaymentMethodDTO> updateUserPaymentMethodDTOs)
        {
            if (await _userPaymentMethodService.UpdateUserPaymentMethods(updateUserPaymentMethodDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update UserPaymentMethod");
        }
    }
}
