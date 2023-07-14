using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<BookGenre> BookGenreSeeder()
    {
        var genres = new List<BookGenre>()
        {
            new BookGenre()
            {
                Id = 1,
                Name = "Science Fiction"
            },
            new BookGenre()
            {
                Id = 2,
                Name = "Fantasy"
            },
            new BookGenre()
            {
                Id = 3,
                Name = "Mystery"
            },
            new BookGenre()
            {
                Id = 4,
                Name = "Romance"
            },
            new BookGenre()
            {
                Id = 5,
                Name = "Thriller"
            },
            new BookGenre()
            {
                Id = 6,
                Name = "Historical Fiction"
            },
            new BookGenre()
            {
                Id = 7,
                Name = "Horror"
            }
        };

        return genres;
    }

}
