namespace eBookStore.Application.DTOs.Book;

public record BookResponseDTO(
    int Id,
    string Title,
    string Description,
    string BookLanguageName,
    string AuthorName,
    int PageCount,
    DateTime PublicationDate,
    string PublisherName,
    int QtyInStock,
    double Price,
    string BookGenreName,
    string DiscountName);
