namespace eBookStore.Application.DTOs.UserReview;

public class UpdateUserReviewDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OrderLineId { get; set; }
    public int RatingValue { get; set; }
    public string Comment { get; set; }
}
