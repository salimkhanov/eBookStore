using eBookStore.Application.DTOs.Book;

namespace eBookStore.Application.Services.Abstract;

public interface IBookService
{
    Task<BookResponseDTO> GetBookById(int bookId);
    Task<List<BookResponseDTO>> GetBooks();
    Task<bool> CreateBook(BookRequestDTO book);
    Task<bool> UpdateBook(BookRequestDTO book);
    Task<bool> DeleteBook(int bookId);
    //Task<bool> BookExists();
}
