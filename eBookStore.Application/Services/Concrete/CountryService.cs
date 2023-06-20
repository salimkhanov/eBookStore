using AutoMapper;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    public CountryService(
        ICountryRepository countryRepository,
        IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public bool ActivateCountry(int countryId)
    {
        var country = _countryRepository.GetById(countryId);
        if (country != null && country.EntityStatus != EntityStatus.Active)
        {
            country.EntityStatus = EntityStatus.Active;
            _countryRepository.Activate(country);
            return true;
        }
        return false;
    }

    public List<GetAllCountryDropDown> AllCountriesForDropDown()
    {
        List<GetAllCountryDropDown> countries = null;

        var countriesEntities = _countryRepository.GetAll();

        countries = countriesEntities.Where(x => x.EntityStatus == EntityStatus.Active)
            .OrderBy(u => u.Id)
            .Select(x => new GetAllCountryDropDown() { Key = x.Id, Value = x.CountryName }).ToList();
        return countries;
    }

    public void CreateCountries(List<CreateCountryDTO> createCountryDTOs)
    {
        foreach (var countryDTO in createCountryDTOs)
        {
            var country = _mapper.Map<Country>(countryDTO);
            _countryRepository.Add(country);
        }
    }

    public void CreateCountry(CreateCountryDTO createCountryDTO)
    {
        var country = _mapper.Map<Country>(createCountryDTO);
        _countryRepository.Add(country);
    }

    public bool DeactivateCountry(int countryId)
    {
        var country = _countryRepository.GetById(countryId);
        if (country != null && country.EntityStatus != EntityStatus.Deactive)
        {
            _countryRepository.Deactivate(country);
            return true;
        }
        return false;
    }

    public bool DeleteCountries(List<int> countries)
    {
        List<Country> countriesToDelete = new List<Country>();
        foreach (var id in countries)
        {
            var country = _countryRepository.GetById(id);
            if (country != null)
            {
                countriesToDelete.Add(country);
            }
        }
        if (countriesToDelete.Count > 0)
        {
            _countryRepository.RemoveRange(countriesToDelete);
            return true;
        }
        return false;
    }

    public bool DeleteCountry(int countryId)
    {
        var country = _countryRepository.GetById(countryId);

        if (country != null)
        {
            _countryRepository.Remove(country);
            return true;
        }
        return false;
    }

    public List<GetCountryDTO> GetCountries()
    {
        var countries = _countryRepository.GetAll();
        return _mapper.Map<List<GetCountryDTO>>(countries);
    }

    public GetCountryDTO GetCountryById(int CountryId)
    {
        var country = _countryRepository.GetById(CountryId);
        return _mapper.Map<GetCountryDTO>(country);
    }

    public bool UpdateCountries(List<UpdateCountryDTO> updateCountryDTOs)
    {
        List<Country> countriesToUpdate = new List<Country>();

        foreach (var countryDTO in updateCountryDTOs)
        {
            var country = _countryRepository.GetById(countryDTO.Id);
            if (country != null)
            {
                country.CountryName = countryDTO.CountryName;
                countriesToUpdate.Add(country);
            }
        }
        if (countriesToUpdate.Count > 0)
        {
            _countryRepository.UpdateRange(countriesToUpdate);
            return true;
        }
        return false;
    }
    public bool UpdateCountry(UpdateCountryDTO updateCountryDTO)
    {
        var country = _countryRepository.GetById(updateCountryDTO.Id);
        if (country != null && country.EntityStatus != EntityStatus.Deactive)
        {
            country.CountryName = updateCountryDTO.CountryName;
            _countryRepository.Update(country);
            return true;
        }
        return false;
    }
}
