using AutoMapper;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<bool> CreateBookAsync(BookRequestDTO bookRequestDTO)
    {
        var book = _mapper.Map<Book>(bookRequestDTO);
        await _bookRepository.AddAsync(book);
        return true;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book != null)
        {
            await _bookRepository.RemoveAsync(book);
            return true;
        }
        return false;
    }

    public async Task<BookResponseDTO> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdIncludeAsync(id);
        return _mapper.Map<BookResponseDTO>(book);
    }

    public async Task<List<BookResponseDTO>> GetBooksAsync()
    {
        var books = await _bookRepository.GetBooksIncludeAsync();
        return _mapper.Map<List<BookResponseDTO>>(books);
    }

    public async Task<bool> UpdateBookAsync(BookRequestDTO bookRequestDTO)
    {
        var book = await _bookRepository.GetByIdAsync(bookRequestDTO.Id);
        if (book != null)
        {
            var mapped = _mapper.Map<Book>(bookRequestDTO);
            await _bookRepository.UpdateAsync(mapped);
            return true;
        }
        return false;
    }
}
