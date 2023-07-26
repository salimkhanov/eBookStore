using AutoMapper;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
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
    public async Task<bool> CountryExistsAsync(string name)
    {
        var country = (await _countryRepository.FindAsync(a => a.Name.Trim().ToLower() == name.Trim().ToLower())).FirstOrDefault();
        if (country == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> CreateCountryAsync(CountryDTO countryDTO)
    {
        if (!await CountryExistsAsync(countryDTO.Name))
        {
            var mapped = _mapper.Map<Country>(countryDTO);
            await _countryRepository.AddAsync(mapped);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteCountryAsync(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        if (country != null)
        {
            await _countryRepository.RemoveAsync(country);
            return true;
        }
        return false;
    }

    public async Task<List<CountryDTO>> GetCountriesAsync()
    {
        var countries = await _countryRepository.GetAllAsync();
        return _mapper.Map<List<CountryDTO>>(countries);
    }

    public async Task<CountryDTO> GetCountryByIdAsync(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        return _mapper.Map<CountryDTO>(country);
    }

    public async Task<bool> UpdateCountryAsync(CountryDTO countryDTO)
    {
        var country = await _countryRepository.GetByIdAsync(countryDTO.Id);
        if (country != null)
        {
            _mapper.Map(countryDTO, country);
            await _countryRepository.UpdateAsync(country);
            return true;
        }
        return false;
    }
}
