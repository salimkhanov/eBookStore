using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Domain.Entities.Authorizations;

public class Role : IdentityRole<int>
{
    public int OrderIndex { get; set; }
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
}
