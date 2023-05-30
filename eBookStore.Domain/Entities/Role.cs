using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Domain.Entities;

public class Role : IdentityRole<int>
{
    public int OrderIndex { get; set; }
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
}