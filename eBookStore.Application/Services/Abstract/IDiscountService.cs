using eBookStore.Application.DTOs.Discount;

namespace eBookStore.Application.Services.Abstract;

public interface IDiscountService
{
    Task CreateDiscountAsync(DiscountDTO discountDTO);  
    Task<DiscountDTO> GetDiscountByIdAsync(int id);
    Task<List<DiscountDTO>> GetDiscountsAsync();
    Task<bool> DeleteDiscountAsync(int id);
    Task<bool> UpdateDiscountAsync(DiscountDTO discountDTO);    
    Task<bool> AddDiscountToBooksAsync(DiscountBookDTO discountBookDTO);
    Task<bool> RemoveDiscountFromAllBooksAsync(int discountId);
    //Task<BookResponseDTO> GetBooksByDiscount(int discount);         
}
