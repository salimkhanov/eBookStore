using Microsoft.AspNetCore.Http;

namespace eBookStore.Application.DTOs.Book;

public record BookUpdateDTO(
    int Id,
    string Title,
    string Description,
    int BookLanguageId,
    int AuthorId,
    int PageCount,
    DateTime PublicationDate,
    int PublisherId,
    int QtyInStock,
    double Price,
    int BookGenreId,
    IFormFile BookImage);   
