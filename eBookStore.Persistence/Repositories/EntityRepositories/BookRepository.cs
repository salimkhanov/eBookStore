using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
}
