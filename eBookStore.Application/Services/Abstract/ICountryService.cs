using eBookStore.Application.DTOs.Country;

namespace eBookStore.Application.Services.Abstract;

public interface ICountryService
{
    Task<CountryDTO> GetCountryByIdAsync(int id);
    Task<List<CountryDTO>> GetCountriesAsync(); 
    Task<bool> CreateCountryAsync(CountryDTO countryDTO);
    Task<bool> UpdateCountryAsync(CountryDTO countryDTO);
    Task<bool> DeleteCountryAsync(int id);
    Task<bool> CountryExistsAsync(string name); 
}
