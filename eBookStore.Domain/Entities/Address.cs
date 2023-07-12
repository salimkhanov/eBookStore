using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Address : BaseEntity
{
    public int StreetNumber { get; set; }
    public string AddressLine { get; set; } = default!; 
    public string City { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public int CountryId { get; set; }


    #region Navigation Properties
    public Country Country { get; set; } = default!;
    public ICollection<UserAddress> UserAddress { get; set; } = new List<UserAddress>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    #endregion
}
