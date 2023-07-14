using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<OrderStatus> OrderStatusSeeder()
    {
        var statuses = new List<OrderStatus>()
        {
            new OrderStatus()
            {
                Id = 1,
                Status = "Processing"
            },
            new OrderStatus()
            {
                Id = 2,
                Status = "Shipped"
            },
            new OrderStatus()
            {
                Id = 3,
                Status = "Completed"
            },
            new OrderStatus()
            {
                Id = 4,
                Status = "Cancelled"
            }
        };

        return statuses;
    }

}
