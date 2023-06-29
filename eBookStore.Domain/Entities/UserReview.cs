using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserReview:BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int OrderLineId { get; set; }
    public int RatingValue { get; set; }
    public string Comment { get; set; }
}
