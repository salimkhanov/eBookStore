namespace eBookStore.Application.DTOs.Book;

public record BookResponseDTO(
    int Id,
    string Title,
    string Description,
    int BookLanguageId,
    int PageCount,
    DateTime PublicationDate,
    int PublisherId,
    int QtyInStock,
    double Price,
    int BookGenreId);
