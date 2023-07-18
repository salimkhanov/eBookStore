using AutoMapper;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class BookGenreService : IBookGenreService
{
    private readonly IBookGenreRepository _bookGenreRepository;
    private readonly IMapper _mapper;

    public BookGenreService(
        IBookGenreRepository bookGenreRepository,
        IMapper mapper)
    {
        _bookGenreRepository = bookGenreRepository;
        _mapper = mapper;
    }
    public async Task<bool> CreateGenreAsync(BookGenreDTO bookGenreDTO)
    {
        if (!await GenreExistsAsync(bookGenreDTO.Name))
        {
            var mapped = _mapper.Map<BookGenre>(bookGenreDTO);
            await _bookGenreRepository.AddAsync(mapped);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteGenreAsync(int id)
    {
        var genre = await _bookGenreRepository.GetByIdAsync(id);
        if (genre != null)
        {
            await _bookGenreRepository.RemoveAsync(genre);
            return true;
        }
        return false;
    }

    public async Task<bool> GenreExistsAsync(string name)
    {
        var genre = (await _bookGenreRepository.FindAsync(a => a.Name.Trim().ToLower() == name.Trim().ToLower())).FirstOrDefault();
        if (genre == null)
        {
            return false;
        }
        return true;
    }

    public async Task<BookGenreDTO> GetGenreByIdAsync(int id)
    {
        var genre = await _bookGenreRepository.GetByIdAsync(id);
        return _mapper.Map<BookGenreDTO>(genre);
    }

    public async Task<List<BookGenreDTO>> GetGenresAsync()
    {
        var genres = await _bookGenreRepository.GetAllAsync();
        return _mapper.Map<List<BookGenreDTO>>(genres);
    }

    public async Task<bool> UpdateGenreAsync(BookGenreDTO bookGenreDTO)
    {
        var genre = await _bookGenreRepository.GetByIdAsync(bookGenreDTO.Id);
        if (genre != null)
        {
            var mapped = _mapper.Map<BookGenre>(bookGenreDTO);
            await _bookGenreRepository.UpdateAsync(mapped);
            return true;
        }
        return false;
    }
}
