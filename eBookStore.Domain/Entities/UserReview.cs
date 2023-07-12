using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserReview : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int OrderedBookId { get; set; }
    public OrderLine OrderLine { get; set; } = default!;
    public int RatingValue { get; set; }
    public string Comment { get; set; } = default!; 
}
