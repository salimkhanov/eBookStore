using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class BookGenre : BaseEntity 
{
    public int Name { get; set; } = default!;
    public ICollection<Book> Books { get; set; } = new List<Book>();   
}
