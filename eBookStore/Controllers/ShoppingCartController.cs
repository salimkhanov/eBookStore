using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Route("/ActivateShoppingCart")]
        [HttpPut]
        public IActionResult ActivateShoppingCart(int shoppingCartId)
        {
            if (_shoppingCartService.ActivateShoppingCart(shoppingCartId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"ShoppingCart with ID {shoppingCartId} not found.");
        }

        [Route("/CreateShoppingCart")]
        [HttpPost]
        public async Task<IActionResult> CreateShoppingCart(CreateShoppingCartDTO createShoppingCartDTO)
        {
            if (await _shoppingCartService.CreateShoppingCart(createShoppingCartDTO))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to Create ShoppingCart");
        }

        [Route("/CreateShoppingCarts")]
        [HttpPost]
        public IActionResult CreateShoppingCarts(List<CreateShoppingCartDTO> createShoppingCartDTOs)
        {

            if (_shoppingCartService.CreateShoppingCarts(createShoppingCartDTOs))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to created");
        }

        [Route("/DeactivateShoppingCart")]
        [HttpPut]
        public IActionResult DeactivateShoppingCart(int shoppingCartId)
        {
            if (_shoppingCartService.DeactivateShoppingCart(shoppingCartId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"ShoppingCart with ID {shoppingCartId} not found.");
        }

        [Route("/DeleteShoppingCart")]
        [HttpDelete]
        public IActionResult DeleteShoppingCart(int shoppingCartId)
        {
            if (_shoppingCartService.DeleteShoppingCart(shoppingCartId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"ShoppingCart with ID {shoppingCartId} not found.");
        }

        [Route("/DeleteShoppingCarts")]
        [HttpDelete]
        public IActionResult DeleteShoppingCarts(List<int> shoppingCarts)
        {
            if (_shoppingCartService.DeleteShoppingCarts(shoppingCarts))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/GetShoppingCartById")]
        [HttpGet]
        public IActionResult GetShoppingCartById(int shoppingCartId)
        {
            var result = _shoppingCartService.GetShoppingCartById(shoppingCartId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/GetAllShoppingCarts")]
        [HttpGet]
        public IActionResult GetAllShoppingCarts()
        {
            return Ok(_shoppingCartService.GetShoppingCarts());
        }

        [Route("/UpdateShoppingCart")]
        [HttpPut]
        public async Task<IActionResult> UpdateShoppingCart(UpdateShoppingCartDTO updateShoppingCartDTO)
        {
            if (await _shoppingCartService.UpdateShoppingCart(updateShoppingCartDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update ShoppingCart");
        }

        [Route("/UpdateShoppingCarts")]
        [HttpPut]
        public async Task<IActionResult> UpdateShoppingCarts(List<UpdateShoppingCartDTO> updateShoppingCartDTOs)
        {
            if (await _shoppingCartService.UpdateShoppingCarts(updateShoppingCartDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update ShoppingCart");
        }

    }
}
