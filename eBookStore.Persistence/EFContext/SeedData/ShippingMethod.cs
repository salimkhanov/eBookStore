using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<ShippingMethod> ShippingMethodSeeder()
    {
        var methods = new List<ShippingMethod>()
        {
            new ShippingMethod()
            {
                Id = 1,
                Name = "Standard Shipping",
                Price = 5.99
            },
            new ShippingMethod()
            {
                Id = 2,
                Name = "Express Shipping",
                Price = 12.99
            },
            new ShippingMethod()
            {
                Id = 3,
                Name = "Free Shipping",
                Price = 0.0
            }
        };
    
        return methods;
    }

}