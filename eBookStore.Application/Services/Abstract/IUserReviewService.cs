using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.UserReview;

namespace eBookStore.Application.Services.Abstract;

public interface IUserReviewService
{
    List<GetUserReviewDTO> GetUserReviews();
    GetUserReviewDTO GetUserReviewById(int userReviewId);
    Task<bool> CreateUserReview(CreateUserReviewDTO createUserReviewDTO);
    Task<bool> UpdateUserReview(UpdateUserReviewDTO updateUserReviewDTO);
    bool DeleteUserReview(int userReviewId);
    bool DeactivateUserReview(int userReviewId);
    bool ActivateUserReview(int userReviewId);
    bool CreateUserReviews(List<CreateUserReviewDTO> createUserReviewDTOs);
    bool DeleteUserReviews(List<int> userReviews);
    Task<bool> UpdateUserReviews(List<UpdateUserReviewDTO> updateUserReviewDTOs);
}
