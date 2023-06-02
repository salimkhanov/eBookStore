using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Domain.Entities;

public class User : IdentityUser<int>
{
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;

    #region Navigation Properties
    public ICollection<UserAddress> UserAddress { get; set; }
    #endregion
}
