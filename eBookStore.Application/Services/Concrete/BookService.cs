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
    public async Task<bool> CreateBook(BookRequestDTO bookRequestDTO)
    {
        var book = _mapper.Map<Book>(bookRequestDTO);
        await _bookRepository.AddAsync(book);
        return true;
    }

    public async Task<bool> DeleteBook(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<BookResponseDTO> GetBookById(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BookResponseDTO>> GetBooks()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateBook(BookRequestDTO book)
    {
        throw new NotImplementedException();
    }
}
