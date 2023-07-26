using AutoMapper;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.BookLanguage;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class BookLanguageService : IBookLanguageService
{
    private readonly IBookLanguageRepository _bookLanguageRepository;
    private readonly IMapper _mapper;

    public BookLanguageService(
        IBookLanguageRepository bookLanguageRepository,
        IMapper mapper)
    {
        _bookLanguageRepository = bookLanguageRepository;
        _mapper = mapper;
    }
    public async Task<bool> CreateLanguageAsync(BookLanguageDTO bookLanguageDTO)
    {
        if (!await LanguageExistsAsync(bookLanguageDTO.Name))
        {
            var mapped = _mapper.Map<BookLanguage>(bookLanguageDTO);
            await _bookLanguageRepository.AddAsync(mapped);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteLanguageAsync(int id)
    {
        var language = await _bookLanguageRepository.GetByIdAsync(id);
        if (language != null)
        {
            await _bookLanguageRepository.RemoveAsync(language);
            return true;
        }
        return false;
    }

    public async Task<BookLanguageDTO> GetLanguageByIdAsync(int id)
    {
        var language = await _bookLanguageRepository.GetByIdAsync(id);
        return _mapper.Map<BookLanguageDTO>(language);
    }

    public async Task<List<BookLanguageDTO>> GetLanguagesAsync()
    {
        var languages = await _bookLanguageRepository.GetAllAsync();
        return _mapper.Map<List<BookLanguageDTO>>(languages);
    }

    public async Task<bool> LanguageExistsAsync(string name)
    {
        var language = (await _bookLanguageRepository.FindAsync(a => a.Name.Trim().ToLower() == name.Trim().ToLower())).FirstOrDefault();
        if (language == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> UpdateLanguageAsync(BookLanguageDTO bookLanguageDTO)
    {
        var language = await _bookLanguageRepository.GetByIdAsync(bookLanguageDTO.Id);
        if (language != null)
        {
            _mapper.Map(bookLanguageDTO, language);
            await _bookLanguageRepository.UpdateAsync(language);
            return true;
        }
        return false;
    }
}
