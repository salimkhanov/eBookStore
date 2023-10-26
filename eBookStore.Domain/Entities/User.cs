using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace eBookStore.Domain.Entities;

public class User : IdentityUser<int>
{
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;

    #region Navigation Properties
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    public virtual ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    #endregion
}
