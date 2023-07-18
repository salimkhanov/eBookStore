using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<Publisher> PublisherSeeder()
    {
        var publishers = new List<Publisher>()
        {
            new Publisher()
            {
                Id = 1,
                Name = "HarperCollins",
            },
            new Publisher()
            {
                Id = 2,
                Name = "Macmillan Publishers"
            }
        };

        return publishers;
    }
}
