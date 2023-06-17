using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.Country;

public class GetCountryDTO
{
    public int Id { get; set; }
    public string CountryName { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
