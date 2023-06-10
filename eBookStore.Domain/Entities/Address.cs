using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Address:BaseEntity
{
    public int UnitNumber { get; set; }
    public int StreetNumber { get; set; }
    public string FullAddress { get; set; }
    public string City { get; set;}
    public string Region { get; set;}
    public string PostalCode { get; set;}

    #region Relations
    public int CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<UserAddress> UserAddress { get; set; }
    #endregion
}
