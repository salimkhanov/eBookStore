using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.Address;

public class GetAddressDTO
{
    public int Id { get; set; }
    public int UnitNumber { get; set; }
    public int StreetNumber { get; set; }
    public string FullAddress { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public int CountryId { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
