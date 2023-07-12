using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Discount : BaseEntity  
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int DiscountRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
