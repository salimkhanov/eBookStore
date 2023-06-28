using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;
        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [Route("/ActivatePaymentType")]
        [HttpPut]
        public IActionResult ActivatePaymentType(int paymentTypeId)
        {
            if (_paymentTypeService.ActivatePaymentType(paymentTypeId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"PaymentType with ID {paymentTypeId} not found.");
        }

        [Route("/CreatePaymentType")]
        [HttpPost]
        public IActionResult CreatePaymentType(CreatePaymentTypeDTO createPaymentTypeDTO)
        {
            _paymentTypeService.CreatePaymentType(createPaymentTypeDTO);
            return Ok("Successfully created");
        }

        [Route("/CreatePaymentTypes")]
        [HttpPost]
        public IActionResult CreatePaymentTypes(List<CreatePaymentTypeDTO> createPaymentTypeDTOs)
        {
            _paymentTypeService.CreatePaymentTypes(createPaymentTypeDTOs);
            return Ok("Successfully created");
        }

        [Route("/DeactivatePaymentType")]
        [HttpPut]
        public IActionResult DeactivatePaymentType(int paymentTypeId)
        {
            if (_paymentTypeService.DeactivatePaymentType(paymentTypeId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"PaymentType with ID {paymentTypeId} not found.");
        }

        [Route("/DeletePaymentType")]
        [HttpDelete]
        public IActionResult DeletePaymentType(int paymentTypeId)
        {
            if (_paymentTypeService.DeletePaymentType(paymentTypeId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"PaymentType with ID {paymentTypeId} not found.");
        }

        [Route("/DeletePaymentTypes")]
        [HttpDelete]
        public IActionResult DeletePaymentTypes(List<int> paymentTypes)
        {
            if (_paymentTypeService.DeletePaymentTypes(paymentTypes))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/GetPaymentTypeById")]
        [HttpGet]
        public IActionResult GetPaymentTypeById(int paymentTypeId)
        {
            var result = _paymentTypeService.GetPaymentTypeById(paymentTypeId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/GetAllPaymentTypes")]
        [HttpGet]
        public IActionResult GetAllPaymentTypes()
        {
            return Ok(_paymentTypeService.GetPaymentTypes());
        }

        [Route("/UpdatePaymentType")]
        [HttpPut]
        public IActionResult UpdatePaymentType(UpdatePaymentTypeDTO updatePaymentTypeDTO)
        {
            if (_paymentTypeService.UpdatePaymentType(updatePaymentTypeDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Failed to Update PaymentType");
        }

        [Route("/UpdatePaymentTypes")]
        [HttpPut]
        public IActionResult UpdatePaymentTypes(List<UpdatePaymentTypeDTO> updatePaymentTypeDTOs)
        {
            if (_paymentTypeService.UpdatePaymentTypes(updatePaymentTypeDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update PaymentType");
        }

    }
}
