using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace eBookStore.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;

    #region Relations
    public ICollection<UserAddress> UserAddress { get; set; }
    #endregion
}
