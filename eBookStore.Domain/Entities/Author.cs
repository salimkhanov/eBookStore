using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = default!;
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
