using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace eBookStore.Domain.Entities;

public class User : IdentityUser<int>
{
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;

    #region Navigation Properties
    public ICollection<UserAddress> UserAddress { get; set; } = new List<UserAddress>();
    public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    public ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    #endregion
}
