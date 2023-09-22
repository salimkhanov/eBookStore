using eBookStore.Application.DTOs.Book;

namespace eBookStore.Application.DTOs.Order;

public record OrderResponseDTO(
    int Id,
    DateTime OrderDate,
    string PaymentMethodName,
    string AddressLine,
    string ShippingMethodName,
    double OrderTotal,
    string OrderStatus,
    List<BookResponseDTO> Books);
