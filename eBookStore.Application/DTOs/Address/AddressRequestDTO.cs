namespace eBookStore.Application.DTOs.Address;

public record AddressRequestDTO(
    int Id,
    int StreetNumber,
    string AddressLine,
    string City,
    string Region,
    string PostalCode,
    int CountryId);
