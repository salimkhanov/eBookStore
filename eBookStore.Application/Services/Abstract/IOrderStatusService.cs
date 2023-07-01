using eBookStore.Application.DTOs.OrderStatus;
using eBookStore.Application.DTOs.ShippingMethod;

namespace eBookStore.Application.Services.Abstract;

public interface IOrderStatusService
{
    List<GetOrderStatusDTO> GetAllOrderStatus();
    GetOrderStatusDTO GetOrderStatusById(int orderStatusId);
    void CreateOrderStatus(CreateOrderStatusDTO createOrderStatusDTO);
    bool UpdateOrderStatus(UpdateOrderStatusDTO updateOrderStatusDTO);
    bool DeleteOrderStatus(int orderStatusId);
    bool DeactivateOrderStatus(int orderStatusId);
    bool ActivateOrderStatus(int orderStatusId);
    void CreateOrderStatusRange(List<CreateOrderStatusDTO> createOrderStatusDTOs);
    bool DeleteOrderStatusRange(List<int> orderStatusRange);
    bool UpdateOrderStatusRange(List<UpdateOrderStatusDTO> updateOrderStatusDTOs);
}
