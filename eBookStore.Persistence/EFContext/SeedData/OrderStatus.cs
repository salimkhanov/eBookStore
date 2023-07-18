using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;

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
                Status = OrderStatuses.Processing.ToString(),
            },
            new OrderStatus()
            {
                Id = 2,
                Status = OrderStatuses.Shipped.ToString(),
            },
            new OrderStatus()
            {
                Id = 3,
                Status = OrderStatuses.OutForDelivery.ToString(),
            },
            new OrderStatus()
            {
                Id = 4,
                Status = OrderStatuses.Delivered.ToString()
            },
            new OrderStatus()
            {
                Id = 5,
                Status = OrderStatuses.Cancelled.ToString()
            }
        };

        return statuses;
    }

}
