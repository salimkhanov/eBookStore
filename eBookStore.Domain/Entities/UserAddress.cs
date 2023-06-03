using eBookStore.Domain.Entities.Authorizations;
using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserAddress : BaseEntity // imtina etmek
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public bool IsMain { get; set; }
}