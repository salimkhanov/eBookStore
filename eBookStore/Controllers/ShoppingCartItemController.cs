using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.ShoppingCartItem;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public ShoppingCartItemController(IShoppingCartItemService shoppingCartItemService)
        {
            _shoppingCartItemService = shoppingCartItemService;
        }

        [Route("/ActivateShoppingCartItem")]
        [HttpPut]
        public IActionResult ActivateShoppingCartItem(int shoppingCartItemId)
        {
            if (_shoppingCartItemService.ActivateShoppingCartItem(shoppingCartItemId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"ShoppingCartItem with ID {shoppingCartItemId} not found.");
        }

        [Route("/CreateShoppingCartItem")]
        [HttpPost]
        public IActionResult CreateShoppingCartItem(CreateShoppingCartItemDTO createShoppingCartItemDTO)
        {
            if (_shoppingCartItemService.CreateShoppingCartItem(createShoppingCartItemDTO))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to Create ShoppingCartItem");
        }

        [Route("/CreateShoppingCartItems")]
        [HttpPost]
        public IActionResult CreateShoppingCartItems(List<CreateShoppingCartItemDTO> createShoppingCartItemDTOs)
        {

            if (_shoppingCartItemService.CreateShoppingCartItems(createShoppingCartItemDTOs))
            {
                return Ok("Successfully created");
            }
            return BadRequest("Failed to created");
        }


        [Route("/DeactivateShoppingCartItem")]
        [HttpPut]
        public IActionResult DeactivateShoppingCartItem(int shoppingCartItemId)
        {
            if (_shoppingCartItemService.DeactivateShoppingCartItem(shoppingCartItemId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"ShoppingCartItem with ID {shoppingCartItemId} not found.");
        }

        [Route("/DeleteShoppingCartItem")]
        [HttpDelete]
        public IActionResult DeleteShoppingCartItem(int shoppingCartItemId)
        {
            if (_shoppingCartItemService.DeleteShoppingCartItem(shoppingCartItemId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"ShoppingCartItem with ID {shoppingCartItemId} not found.");
        }


        [Route("/DeleteShoppingCartItems")]
        [HttpDelete]
        public IActionResult DeleteShoppingCartItems(List<int> shoppingCartItems)
        {
            if (_shoppingCartItemService.DeleteShoppingCartItems(shoppingCartItems))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/GetShoppingCartItemById")]
        [HttpGet]
        public IActionResult GetShoppingCartItemById(int shoppingCartItemId)
        {
            var result = _shoppingCartItemService.GetShoppingCartItemById(shoppingCartItemId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/GetAllShoppingCartItems")]
        [HttpGet]
        public IActionResult GetAllShoppingCartItems()
        {
            return Ok(_shoppingCartItemService.GetShoppingCartItems());
        }


        [Route("/UpdateShoppingCartItem")]
        [HttpPut]
        public IActionResult UpdateShoppingCartItem(UpdateShoppingCartItemDTO updateShoppingCartItemDTO)
        {
            if (_shoppingCartItemService.UpdateShoppingCartItem(updateShoppingCartItemDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update ShoppingCartItem");
        }

        [Route("/UpdateShoppingCartItems")]
        [HttpPut]
        public IActionResult UpdateShoppingCartItems(List<UpdateShoppingCartItemDTO> updateShoppingCartItemDTOs)
        {
            if (_shoppingCartItemService.UpdateShoppingCartItems(updateShoppingCartItemDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update ShoppingCartItems");
        }
    }
}
