using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class BookAuthor : BaseEntity
{
    public Book Book { get; set; } = default!;
    public int BookId { get; set; }
    public Author Author { get; set; } = default!;
    public int AuthorId { get; set; } = default!;
}
