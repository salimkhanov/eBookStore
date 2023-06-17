using eBookStore.Application.DTOs.Country;

namespace eBookStore.Application.Services.Abstract;

public interface ICountryService
{
    List<GetCountryDTO> GetCountries();
    GetCountryDTO GetCountryById(int CountryId);
    void CreateCountry(CreateCountryDTO createCountryDTO);
    bool UpdateCountry(UpdateCountryDTO updateCountryDTO);
    bool DeleteCountry(int countryId);
    bool DeactivateCountry(int countryId);
    bool ActivateCountry(int countryId);
    List<GetAllCountryDropDown> AllCountriesForDropDown();
    void CreateCountries(List<CreateCountryDTO> createCountryDTOs);
    bool DeleteCountries(List<int> countries);
    bool UpdateCountries(List<UpdateCountryDTO> updateCountryDTOs);
}
