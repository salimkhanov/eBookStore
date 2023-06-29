namespace eBookStore.Application.DTOs.UserReview;

public class CreateUserReviewDTO
{
    public int UserId { get; set; }
    public int OrderLineId { get; set; }
    public int RatingValue { get; set; }
    public string Comment { get; set; }
}
