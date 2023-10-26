using AutoMapper;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Shared.Helper.FileHelper;

namespace eBookStore.Application.Services.Concrete;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService; 

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper,
        IFileService fileService)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _fileService = fileService;
    }
    public async Task<bool> CreateBookAsync(BookRequestDTO bookRequestDTO)
    {
        var book = _mapper.Map<Book>(bookRequestDTO);
        if(_fileService.IsImage(bookRequestDTO.BookImage))
        {
            book.ImagePath = _fileService.Upload(bookRequestDTO.BookImage);
            await _bookRepository.AddAsync(book);
            return true;
        }
        return false;
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
        var book = await _bookRepository.GetByIdAsync(id);
        return _mapper.Map<BookResponseDTO>(book);
    }

    public async Task<List<BookResponseDTO>> GetBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return _mapper.Map<List<BookResponseDTO>>(books);
    }

    public async Task<bool> UpdateBookAsync(BookRequestDTO bookRequestDTO)
    {
        var book = await _bookRepository.GetByIdAsync(bookRequestDTO.Id);
        if (book != null)
        {
            _mapper.Map(bookRequestDTO, book);
            await _bookRepository.UpdateAsync(book);
            return true;
        }
        return false;
    }
}
