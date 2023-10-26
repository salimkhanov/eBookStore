namespace eBookStore.Application.DTOs.Address;

public record AddressResponseDTO(
    int Id,
    int UserId,
    int StreetNumber,
    string AddressLine,
    string City,
    string Region,
    string PostalCode,
    string CountryName);

