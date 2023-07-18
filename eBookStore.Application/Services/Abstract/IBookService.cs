using eBookStore.Application.DTOs.Book;

namespace eBookStore.Application.Services.Abstract;

public interface IBookService
{
    Task<BookResponseDTO> GetBookByIdAsync(int id);
    Task<List<BookResponseDTO>> GetBooksAsync();
    Task<bool> CreateBookAsync(BookRequestDTO book);
    Task<bool> UpdateBookAsync(BookRequestDTO book);
    Task<bool> DeleteBookAsync(int id);
}
