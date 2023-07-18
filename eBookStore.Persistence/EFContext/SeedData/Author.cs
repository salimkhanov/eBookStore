using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder 
{
    public static List<Author> AuthorSeeder()
    {
        var authors = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Stephen King",
            },
            new Author()
            {
                Id = 2,
                Name = "J. K. Rowling"
            }
        };

        return authors;
    }
}
