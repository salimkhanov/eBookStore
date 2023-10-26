using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Address : BaseEntity
{
    public int StreetNumber { get; set; }
    public string AddressLine { get; set; } = default!; 
    public string City { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public bool IsDefault { get; set; }
    public int CountryId { get; set; }
    public int UserId { get; set; }


    #region Navigation Properties
    public virtual Country Country { get; set; } = default!;
    public virtual User User { get; set; } = default!;
    #endregion
}
