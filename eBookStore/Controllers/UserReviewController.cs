using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.UserReview;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserReviewController : ControllerBase
{
    private readonly IUserReviewService _userReviewService;

	public UserReviewController(IUserReviewService userReviewService)
	{
		_userReviewService = userReviewService;
	}

    [Route("/ActivateUserReview")]
    [HttpPut]
    public IActionResult ActivateUserReview(int userReviewId)
    {
        if (_userReviewService.ActivateUserReview(userReviewId))
        {
            return Ok("Successfully activated");
        }
        return BadRequest($"UserReview with ID {userReviewId} not found.");
    }

    [Route("/CreateUserReview")]
    [HttpPost]
    public async Task<IActionResult> CreateUserReview(CreateUserReviewDTO createUserReviewDTO)
    {
        if (await _userReviewService.CreateUserReview(createUserReviewDTO))
        {
            return Ok("Successfully created");
        }
        return BadRequest("Failed to Create UserReview");
    }

    [Route("/CreateUserReviews")]
    [HttpPost]
    public IActionResult CreateUserReviews(List<CreateUserReviewDTO> createUserReviewDTOs)
    {

        if (_userReviewService.CreateUserReviews(createUserReviewDTOs))
        {
            return Ok("Successfully created");
        }
        return BadRequest("Failed to created");
    }

    [Route("/DeactivateUserReview")]
    [HttpPut]
    public IActionResult DeactivateUserReview(int userReviewId)
    {
        if (_userReviewService.DeactivateUserReview(userReviewId))
        {
            return Ok("Successfully deactivated");
        }
        return BadRequest($"UserReview with ID {userReviewId} not found.");
    }

    [Route("/DeleteUserReview")]
    [HttpDelete]
    public IActionResult DeleteUserReview(int userReviewId)
    {
        if (_userReviewService.DeleteUserReview(userReviewId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"UserReview with ID {userReviewId} not found.");
    }

    [Route("/DeleteUserReviews")]
    [HttpDelete]
    public IActionResult DeleteUserReviews(List<int> userReviews)
    {
        if (_userReviewService.DeleteUserReviews(userReviews))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest("Failed to delete");
    }

    [Route("/GetUserReviewById")]
    [HttpGet]
    public IActionResult GetUserReviewById(int userReviewId)
    {
        var result = _userReviewService.GetUserReviewById(userReviewId);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest("Nothing Found");
    }

    [Route("/GetAllUserReviews")]
    [HttpGet]
    public IActionResult GetAllUserReviews()
    {
        return Ok(_userReviewService.GetUserReviews());
    }

    [Route("/UpdateUserReview")]
    [HttpPut]
    public async Task<IActionResult> UpdateUserReview(UpdateUserReviewDTO updateUserReviewDTO)
    {
        if (await _userReviewService.UpdateUserReview(updateUserReviewDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"Failed to Update UserReview");
    }

    [Route("/UpdateUserReviews")]
    [HttpPut]
    public async Task<IActionResult> UpdateUserReviews(List<UpdateUserReviewDTO> updateUserReviewDTOs)
    {
        if (await _userReviewService.UpdateUserReviews(updateUserReviewDTOs))
        {
            return Ok("Successfully updated");
        }
        return BadRequest("Failed to update UserReview");
    }
}
