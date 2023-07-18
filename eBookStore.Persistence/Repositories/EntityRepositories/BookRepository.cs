using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public async Task<IEnumerable<Book>> GetBooksIncludeAsync()
    {
        return await _dbContext.Books
            .OrderBy(b => b.Id)
            .Include(b => b.BookGenre)
            .Include(b => b.BookLanguage)
            .Include(b => b.Publisher)
            .Include(b => b.Discount)
            .Include(b => b.Author).ToListAsync();
    }

    public async Task<Book> GetBookByIdIncludeAsync(int id)
    {
        return await _dbContext.Books
            .Where(b => b.Id == id)
            .OrderBy(b => b.Id)
            .Include(b => b.BookGenre)
            .Include(b => b.BookLanguage)
            .Include(b => b.Publisher)
            .Include(b => b.Author).FirstOrDefaultAsync();
    }
}
