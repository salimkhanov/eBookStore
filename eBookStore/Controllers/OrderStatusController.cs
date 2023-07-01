using eBookStore.Application.DTOs.OrderStatus;
using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [Route("/ActivateOrderStatus")]
        [HttpPut]
        public IActionResult ActivateOrderStatus(int orderStatusId)
        {
            if (_orderStatusService.ActivateOrderStatus(orderStatusId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"OrderStatus with ID {orderStatusId} not found.");
        }

        [Route("/CreateOrderStatus")]
        [HttpPost]
        public IActionResult CreateOrderStatus(CreateOrderStatusDTO createOrderStatusDTO)
        {
            _orderStatusService.CreateOrderStatus(createOrderStatusDTO);
            return Ok("Successfully created");
        }

        [Route("/CreateOrderStatusRange")]
        [HttpPost]
        public IActionResult CreateOrderStatusRange(List<CreateOrderStatusDTO> createOrderStatusDTOs)
        {
            _orderStatusService.CreateOrderStatusRange(createOrderStatusDTOs);
            return Ok("Successfully created");
        }

        [Route("/DeactivateOrderStatus")]
        [HttpPut]
        public IActionResult DeactivateOrderStatus(int orderStatusId)
        {
            if (_orderStatusService.DeactivateOrderStatus(orderStatusId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"OrderStatus with ID {orderStatusId} not found.");
        }

        [Route("/DeleteOrderStatus")]
        [HttpDelete]
        public IActionResult DeleteOrderStatus(int orderStatusId)
        {
            if (_orderStatusService.DeleteOrderStatus(orderStatusId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"OrderStatus with ID {orderStatusId} not found.");
        }

        [Route("/DeleteOrderStatusRange")]
        [HttpDelete]
        public IActionResult DeleteOrderStatusRange(List<int> orderStatusRange)
        {
            if (_orderStatusService.DeleteOrderStatusRange(orderStatusRange))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/GetOrderStatusById")]
        [HttpGet]
        public IActionResult GetOrderStatusById(int orderStatusId)
        {
            var result = _orderStatusService.GetOrderStatusById(orderStatusId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/GetAllOrderStatus")]
        [HttpGet]
        public IActionResult GetAllOrderStatus()
        {
            return Ok(_orderStatusService.GetAllOrderStatus());
        }

        [Route("/UpdateOrderStatus")]
        [HttpPut]
        public IActionResult UpdateOrderStatus(UpdateOrderStatusDTO updateOrderStatusDTO)
        {
            if (_orderStatusService.UpdateOrderStatus(updateOrderStatusDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update OrderStatus");
        }

        [Route("/UpdateOrderStatusRange")]
        [HttpPut]
        public IActionResult UpdateOrderStatusRange(List<UpdateOrderStatusDTO> updateOrderStatusDTOs)
        {
            if (_orderStatusService.UpdateOrderStatusRange(updateOrderStatusDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update OrderStatus");
        }
    }
}
