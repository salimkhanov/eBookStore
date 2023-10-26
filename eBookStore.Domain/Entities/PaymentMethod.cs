using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class PaymentMethod : BaseEntity
{
    public string CardHolderName { get; set; } = default!;
    public string CardNumber { get; set; } = default!;
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public bool IsDefault { get; set; }
    public int UserId { get; set; } 


    // Foreign key to link the payment method to a user
    public virtual User User { get; set; } = default!;
}
