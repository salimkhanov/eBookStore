using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.DTOs.Order;
using eBookStore.Domain.Entities;

namespace eBookStore.Application.Services.Abstract;

public interface IOrderService
{
    Task CreateOrder(OrderCreateDTO orderCreateDTO);
    Task<List<OrderResponseDTO>> GetOrdersByUserIdAsync(int userId);
    Task<bool> UpdateOrderAsync(BookGenreDTO bookGenreDTO);
    Task<bool> DeleteOrderAsync(int id);
}
