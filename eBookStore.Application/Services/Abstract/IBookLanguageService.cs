using eBookStore.Application.DTOs.BookLanguage;

namespace eBookStore.Application.Services.Abstract;

public interface IBookLanguageService
{
    Task<List<BookLanguageDTO>> GetLanguagesAsync();
    Task<BookLanguageDTO> GetLanguageByIdAsync(int id);
    Task<bool> CreateLanguageAsync(BookLanguageDTO bookLanguageDTO);
    Task<bool> UpdateLanguageAsync(BookLanguageDTO bookLanguageDTO);
    Task<bool> DeleteLanguageAsync(int id);
    Task<bool> LanguageExistsAsync(string name); 
    
}
