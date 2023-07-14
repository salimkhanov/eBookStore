using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<BookLanguage> BookLanguageSeeder()
    {
        var languages = new List<BookLanguage>()
        {
            new BookLanguage()
            {
                Id = 1,
                LanguageCode = "en",
                Name = "English"
            },
            new BookLanguage()
            {
                Id = 2,
                LanguageCode = "fr",
                Name = "French"
            },
            new BookLanguage()
            {
                Id = 3,
                LanguageCode = "es",
                Name = "Spanish"
            },
            new BookLanguage()
            {
                Id = 4,
                LanguageCode = "de",
                Name = "German"
            }
        };

        return languages;
    }

}
