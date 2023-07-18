using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Book;

namespace eBookStore.Application.Services.Abstract;

public interface IAuthorService
{
    Task<List<AuthorDTO>> GetAuthorsAsync();
    Task<AuthorDTO> GetAuthorByIdAsync(int id);    
    Task<bool> CreateAuthorAsync(AuthorDTO authorDTO);
    Task<bool> UpdateAuthorAsync(AuthorDTO authorDTO);
    Task<bool> DeleteAuthorAsync(int id);
    Task<bool> AuthorExistsAsync(string name);
}
