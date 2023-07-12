using eBookStore.Domain.Entities.Base;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace eBookStore.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
