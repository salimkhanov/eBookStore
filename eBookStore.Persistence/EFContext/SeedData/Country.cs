using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<Country> CountrySeeder()
    {
        var countries = new List<Country>()
        {
            new Country()
            {
                Id = 1,
                Name = "Azerbaijan"
            },
            new Country()
            {
                Id = 2,
                Name = "Turkey"
            },
            new Country()
            {
                Id = 3,
                Name = "United States"
            },
            new Country()
            {
                Id = 4,
                Name = "United Kingdom"
            },
            new Country()
            {
                Id = 5,
                Name = "Canada"
            },
            new Country()
            {
                Id = 6,
                Name = "Australia"
            },
            new Country()
            {
                Id = 7,
                Name = "Germany"
            },
            new Country()
            {
                Id = 8,
                Name = "France"
            },
            new Country()
            {
                Id = 9,
                Name = "Japan"
            },
            new Country()
            {
                Id = 10,
                Name = "China"
            }
        };

        return countries;
    }


}
