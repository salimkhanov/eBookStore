using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class BookLanguage : BaseEntity
{
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
