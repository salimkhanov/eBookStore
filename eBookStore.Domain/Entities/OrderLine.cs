using eBookStore.Domain.Entities.Base;
using System.ComponentModel;

namespace eBookStore.Domain.Entities;

public class OrderLine : BaseEntity
{
    public Book Book { get; set; } = default!;
    public int BookId { get; set; }
    public Order Order { get; set; } = default!;
    public int OrderId { get; set; }
    public int Qty { get; set; }  
    public double Price { get; set; }
    public ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
}
