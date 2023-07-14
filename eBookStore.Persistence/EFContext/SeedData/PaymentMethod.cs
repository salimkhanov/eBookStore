using eBookStore.Domain.Entities;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static List<PaymentMethod> PaymentMethodSeeder()
    {
        var methods = new List<PaymentMethod>()
        {
            new PaymentMethod()
            {
                Id = 1,
                Method = "Credit Card"
            },
            new PaymentMethod()
            {
                Id = 2,
                Method = "PayPal"
            },
            new PaymentMethod()
            {
                Id = 3,
                Method = "Bank Transfer"
            },
            new PaymentMethod()
            {
                Id = 4,
                Method = "Cash on Delivery"
            }
        };

        return methods;
    }

}
