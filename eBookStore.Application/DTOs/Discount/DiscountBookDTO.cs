namespace eBookStore.Application.DTOs.Discount;

public record DiscountBookDTO(
    int DiscountId,
    int[] BookIds);
