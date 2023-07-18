using eBookStore.Domain.Entities;

namespace eBookStore.Domain.Repositories.EntityRepositories;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksIncludeAsync();
    Task<Book> GetBookByIdIncludeAsync(int id);
}
