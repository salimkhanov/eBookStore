namespace eBookStore.Application.DTOs.Discount;

public record DiscountDTO(
    int Id,
    string Name,
    string Description,
    int DiscountRate,
    DateTime StartDate,
    DateTime EndDate);