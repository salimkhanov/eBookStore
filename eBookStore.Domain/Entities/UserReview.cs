using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserReview : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int BookId { get; set; }
    public virtual Book Book { get; set; } = default!;
    public int RatingValue { get; set; }
    public string Comment { get; set; } = default!;
}
