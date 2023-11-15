using eBookStore.Application.DTOs.OrderStatus;

namespace eBookStore.Application.Services.Abstract;

public interface IOrderStatusService
{
    Task<List<OrderStatusDTO>> GetOrderStatusesAsync();
    Task<OrderStatusDTO> GetOrderStatusByIdAsync(int id);
    Task CreateOrderStatus(OrderStatusDTO orderStatusDTO);
    Task<bool> UpdateOrderStatusAsync(OrderStatusDTO orderStatusDTO);
    Task<bool> DeleteOrderStatusAsync(int id);
}
