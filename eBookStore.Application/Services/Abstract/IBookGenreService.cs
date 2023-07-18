using eBookStore.Application.DTOs.BookGenre;

namespace eBookStore.Application.Services.Abstract;

public interface IBookGenreService
{
    Task<List<BookGenreDTO>> GetGenresAsync();
    Task<BookGenreDTO> GetGenreByIdAsync(int id);
    Task<bool> CreateGenreAsync(BookGenreDTO bookGenreDTO);
    Task<bool> UpdateGenreAsync(BookGenreDTO bookGenreDTO);
    Task<bool> DeleteGenreAsync(int id);     
    Task<bool> GenreExistsAsync(string name);
}
