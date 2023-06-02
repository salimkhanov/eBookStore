using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Address : BaseEntity
{
    public int UnitNumber { get; set; }
    public int StreetNumber { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public int CountryId { get; set; }


    #region Navigation Properties
    public Country Country { get; set; }
    public ICollection<UserAddress> UserAddress { get; set; }
    #endregion
}
